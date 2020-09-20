using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using ADALotto.Enumerations;
using ADALotto.Models;
using ReactiveUI;
using ShellLink;
using System.Linq;
using System.Threading.Tasks;
using SAIB.CardanoWallet.NET;

namespace ADALotto.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		
		#region Properties
        public string DaedalusInstallPath { get; private set; } = string.Empty;
        public string DaedalusStateDir { get; private set; } = string.Empty;
        public Process? CardanoNodeProcess { get; private set; }
        private AppStatus _appStatus = AppStatus.Offline;
        public AppStatus AppStatus
        {
            get => _appStatus;
            set
            {
                this.RaiseAndSetIfChanged(ref _appStatus, value);
                this.RaisePropertyChanged("IsSynced");
            }
        }
        private double _nodeSyncProgress = 0;
        public double NodeSyncProgress
        {
            get => _nodeSyncProgress;
            set => this.RaiseAndSetIfChanged(ref _nodeSyncProgress, value);
        }
        private int _epoch = 0;
        public int Epoch
        {
            get => _epoch;
            set => this.RaiseAndSetIfChanged(ref _epoch, value);
        }
        private int _slotInEpoch = 0;
        public int SlotInEpoch
        {
            get => _slotInEpoch;
            set => this.RaiseAndSetIfChanged(ref _slotInEpoch, value);
        }
        private int _blockNo = 0;
        public int BlockNo
        {
            get => _blockNo;
            set => this.RaiseAndSetIfChanged(ref _blockNo, value);
        }
        public bool IsSynced
        {
            get
            {
                return AppStatus == AppStatus.Online;
            }
        }
        public bool IsNotSynced
        {
            get
            {
                return AppStatus != AppStatus.Online;
            }
        }
        public int Digits { get; set; } = 6;
		#endregion
		#region Events
		public event EventHandler? NewWalletRequest;
		#endregion
        #region Constants
        private readonly string CARDANO_SOCKET_PATH = "\"\\\\.\\pipe\\cardano-lotto\"";
        private readonly int CARDANO_PORT = 11337;
        private readonly int CARADANO_WALLET_PORT = 11338;
        #endregion
        #region Private Properties
        private HttpClient HttpClient { get; set; } = new HttpClient();
        private string TempPath { get; set; } = string.Empty;
        private bool IsWalletStarted { get; set; }
        private CardanoWallet? CurrentWallet { get; set; }
        #endregion

        /// <summary>
        /// @TODO parts of it to be moved to Cardano.NET Library
        /// </summary>
        public async Task InitializeCardanoNodeAsync()
        {
            await Task.Run(() =>
            {
                AppStatus = AppStatus.Starting;
                // Get Start Menu Daedalus Link
                var startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
                var daedalusShortcut = Path.Combine(startMenuPath, "Programs", "Daedalus Mainnet", "Daedalus Mainnet.lnk");

                // Get Daedalus Install Dir from Link
                var shortcut = Shortcut.ReadFromFile(daedalusShortcut);
                DaedalusInstallPath = shortcut.StringData.WorkingDir;

                // Get Daedalus State Dir
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                DaedalusStateDir = GetDaedalusStateDir().Replace("${APPDATA}", appData);

                // Get OS Temp Path
                TempPath = Path.Combine(Path.GetTempPath(), "adalotto");

                // Prepare Config files for Cardano Node
                PrepareConfigFiles();

                // Copy the blockchain data so we don't mess around with daedalus running
                if (!Directory.Exists(Path.Combine(DaedalusStateDir, "lotto-chain")))
                {
                    var daedalusChain = Path.Combine(DaedalusStateDir, "chain");
                    var lottoChain = Path.Combine(DaedalusStateDir, "lotto-chain");
                    DirectoryCopy(daedalusChain, lottoChain, true);
                }

                CardanoNodeProcess = new Process();
                CardanoNodeProcess.StartInfo = new ProcessStartInfo
                {
                    FileName = $"{DaedalusInstallPath}\\cardano-node.exe",
                    Arguments = string.Join(
                        " ",
                        "run",
                        "--topology", $"\"{TempPath}\\config\\topology.json\"",
                        "--database-path", $"\"{Path.Combine(DaedalusStateDir, "lotto-chain")}\"",
                        "--config", $"\"{TempPath}\\config\\config.json\"",
                        "--port", CARDANO_PORT,
                        "--host-addr", "\"0.0.0.0\"",
                        $"--socket-path={CARDANO_SOCKET_PATH}"
                    ),
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                CardanoNodeProcess.OutputDataReceived += OnOutputDataReceived;
                CardanoNodeProcess.Start();
                CardanoNodeProcess.BeginOutputReadLine();
            });
        }

        private void PrepareConfigFiles()
        {
            var assembly = typeof(Program).Assembly;
            var resources = assembly.GetManifestResourceNames();

            foreach (string resource in resources)
            {
                if (!resource.Contains("!AvaloniaResources"))
                {
                    var resourceSplit = resource.Split('.');
                    var resourceDir = string.Join("/", resourceSplit.Skip(1).Take(resourceSplit.Length - 3).ToArray());
                    var resourceFile = $"{resourceSplit[resourceSplit.Length - 2]}.{resourceSplit[resourceSplit.Length - 1]}";

                    if (!Directory.Exists(Path.Combine(TempPath, resourceDir)))
                        Directory.CreateDirectory(Path.Combine(TempPath, resourceDir));

                    using var resourceStream = assembly.GetManifestResourceStream(resource);
                    if (resourceStream != null)
                    {
                        using var fileStream = new FileStream(
                            Path.Combine(TempPath, resourceDir, resourceFile),
                            FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        resourceStream.CopyTo(fileStream);
                    }
                    else
                    {
                        //@TODO do something about null
                    }
                }
            }

            File.Copy(
                Path.Combine(DaedalusInstallPath, "genesis-byron.json"),
                Path.Combine(TempPath, "config", "genesis-byron.json"),
                true
            );

            File.Copy(
                Path.Combine(DaedalusInstallPath, "genesis-shelley.json"),
                Path.Combine(TempPath, "config", "genesis-shelley.json"),
                true
            );

            File.Copy(
                Path.Combine(DaedalusInstallPath, "topology.yaml"),
                Path.Combine(TempPath, "config", "topology.json"),
                true
            );
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private string GetDaedalusStateDir()
        {
            var launcherConfig = JsonSerializer
                .Deserialize<DaedalusLauncherConfig>(
                    File.ReadAllText(Path.Combine(DaedalusInstallPath, "launcher-config.yaml")));
            return launcherConfig.StateDir;
        }

        private async void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                Console.WriteLine(e.Data);
                if (e.Data.Contains("block replay progress (%)"))
                {
                    AppStatus = AppStatus.Validating;
                    var dataSplt = e.Data.Split("=");
                    double p = 0;
                    double.TryParse(dataSplt[1], out p);
                    NodeSyncProgress = p;
                }

                if (e.Data.Contains("Opened lgr db"))
                {
                    AppStatus = AppStatus.Opening;
                    NodeSyncProgress = 100;
                }

                if (e.Data.Contains("Chain extended"))
                {
                    AppStatus = AppStatus.Online;
                    NodeSyncProgress = 100;

                    var metricString = await HttpClient.GetStringAsync("http://127.0.0.1:12798/metrics");
                    var metrics = metricString.Split('\n');

                    Epoch = int.Parse(metrics
                        .Where((s) => s.Contains("cardano_node_ChainDB_metrics_epoch_int"))
                        .Select((s) => s.Split(" ")[1]).FirstOrDefault());

                    SlotInEpoch = int.Parse(metrics
                        .Where((s) => s.Contains("cardano_node_ChainDB_metrics_slotInEpoch_int"))
                        .Select((s) => s.Split(" ")[1]).FirstOrDefault());

                    BlockNo = int.Parse(metrics
                        .Where((s) => s.Contains("cardano_node_ChainDB_metrics_blockNum_int"))
                        .Select((s) => s.Split(" ")[1]).FirstOrDefault());

                    if (!IsWalletStarted)
                    {
                        IsWalletStarted = true;
                        StartWallet();
                    }

                }
            }
        }

        private void StartWallet()
        {
            var walletPath = Path.Combine(DaedalusInstallPath, "cardano-wallet.exe");
            var walletDbPath = Path.Combine(DaedalusStateDir, "lotto-wallets");
            CardanoWalletAPI.Initialize(
                walletPath,
                CARDANO_SOCKET_PATH,
                $"\"{walletDbPath}\"",
                CARADANO_WALLET_PORT
            );
            CardanoWalletAPI.StartWallet();
			NewWalletRequest?.Invoke(this, new EventArgs());
        }

		public void GenerateWalletWithPass(string pass)
		{
			CurrentWallet = new CardanoWallet("adalotto", pass);
		}

        public void StopNode()
        {
            CardanoWalletAPI.StopWallet();
            CardanoNodeProcess?.Kill(true);
            AppStatus = AppStatus.Offline;
        }
    }
}
