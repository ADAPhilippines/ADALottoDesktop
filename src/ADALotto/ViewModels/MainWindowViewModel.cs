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

namespace ADALotto.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public string DaedalusInstallPath { get; private set; }
		public Process CardanoNodeProcess { get; private set; }
		private CardanoNodeStatus _nodeStatus = CardanoNodeStatus.Offline;
		public CardanoNodeStatus NodeStatus
		{
			get => _nodeStatus;
			set => this.RaiseAndSetIfChanged(ref _nodeStatus, value);
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
		public int Digits { get; set; } = 6;
		private HttpClient HttpClient { get; set; } = new HttpClient();
		private readonly string CARDANO_SOCKET_PATH = "\"\\\\.\\pipe\\cardano-lotto\"";
		private readonly int CARDANO_PORT = 11337;

		/// <summary>
		/// @TODO parts of it to be moved to Cardano.NET Library
		/// </summary>
		public void InitializeCardanoNode()
		{
			NodeStatus = CardanoNodeStatus.Starting;
			//Get Start Menu Daedalus Link
			var startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
			var daedalusShortcut = Path.Combine(startMenuPath, "Programs", "Daedalus Mainnet", "Daedalus Mainnet.lnk");

			// Get Daedalus Install Dir from Link
			var shortcut = Shortcut.ReadFromFile(daedalusShortcut);
			DaedalusInstallPath = shortcut.StringData.WorkingDir;

			//Get Daedalus State Dir
			var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var stateDir = GetDaedalusStateDir().Replace("${APPDATA}", appData);

			CardanoNodeProcess = new Process();
			CardanoNodeProcess.StartInfo = new ProcessStartInfo
			{
				FileName = $"{DaedalusInstallPath}\\cardano-node.exe",
				Arguments = string.Join(
					" ",
					"run",
					"--topology", $"\"{DaedalusInstallPath}\\topology.yaml\"",
					"--database-path", $"\"{Path.Combine(stateDir, "chain")}\"",
					"--config", $"\"{DaedalusInstallPath}\\config.yaml\"",
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
			Console.WriteLine(e.Data);
			if (e.Data.Contains("block replay progress (%)"))
			{
				NodeStatus = CardanoNodeStatus.BlockReplay;
				var dataSplt = e.Data.Split("=");
				double p = 0;
				double.TryParse(dataSplt[1], out p);
				NodeSyncProgress = p;
			}

			if (e.Data.Contains("Opened lgr db"))
			{
				NodeStatus = CardanoNodeStatus.OpeningDatabase;
				NodeSyncProgress = 100;
			}

			if (e.Data.Contains("Chain extended"))
			{
				NodeStatus = CardanoNodeStatus.Online;
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

			}
		}

		public void StopNode()
		{
			CardanoNodeProcess.Kill(true);
			NodeStatus = CardanoNodeStatus.Offline;
		}
	}
}
