using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using SAIB.CardanoWallet.NET.Models;
using SAIB.CardanoWallet.NET.Models.Payloads;
using System;
using SAIB.CardanoWallet.NET.Models.Responses;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SAIB.CardanoWallet.NET.Helpers;

namespace SAIB.CardanoWallet.NET
{
    public class CardanoWalletAPI
    {
        public static string CardanoWalletBinaryPath { get; set; } = string.Empty;
        public static string CardanoWalletEndpoint
        {
            get
            {
                return "http://localhost:11338";
            }
        }
        public static int CardanoWalletPort { get; set; } = 11338;
        public static string CardanoNodeSocketPath { get; set; } = string.Empty;
        public static string CardanoWalletDatabasePath { get; set; } = string.Empty;
        private static HttpClient HttpClient { get; set; } = new HttpClient();
        private static Process? WalletProcess { get; set; }

        public static void Initialize(
            string walletBinPath,
            string nodeSocketPath,
            string walletDbPath,
            int? walletPort = null
        )
        {
            CardanoWalletBinaryPath = walletBinPath;
            CardanoNodeSocketPath = nodeSocketPath;
            CardanoWalletDatabasePath = walletDbPath;
            CardanoWalletPort = walletPort ?? CardanoWalletPort;
        }

        public static void StartWallet()
        {
            WalletProcess = new Process();
            WalletProcess.StartInfo = new ProcessStartInfo
            {
                FileName = CardanoWalletBinaryPath,
                Arguments = string.Join(" ",
                "serve",
                "--port", CardanoWalletPort,
                "--node-socket", CardanoNodeSocketPath,
                "--database", CardanoWalletDatabasePath,
                "--mainnet"),
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            WalletProcess.OutputDataReceived += (object sender, DataReceivedEventArgs e) => Console.WriteLine(e.Data);
            WalletProcess.Start();
            WalletProcess.BeginOutputReadLine();
        }

        public static void StopWallet()
        {
            WalletProcess?.Kill();
        }

        public static async Task<string[]> GenerateMnemonicsAsync(int? size = 24)
        {

            var result = await Cli.Wrap(CardanoWalletBinaryPath)
                    .WithArguments(size == null ? "recovery-phrase generate" : $"recovery-phrase generate --size {size}")
                    .ExecuteBufferedAsync();

            var mnemonics = result.StandardOutput
                .Replace("\n", string.Empty)
                .Split(' ').Where(s => s.Length > 0).ToArray();

            return mnemonics;
        }

        public static async Task<NetworkInfo> GetNetworkInformation()
        {
            var result = await HttpGetAsync<NetworkInfo>("/v2/network/information");
            return result;
        }

        public static async Task<string> RestoreWalletAsync(string name, string[] mnemonic, string passphrase)
        {
            var result = await HttpPostJsonAsync<WalletResponse, WalletRestorePayload>("/v2/wallets", new WalletRestorePayload
            {
                Name = name,
                MnemonicSeed = mnemonic,
                Passphrase = passphrase
            });
            return result.Id;
        }

        public static async Task<WalletResponse> GetWalletsByIdAsync(string id)
        {
            return await HttpGetAsync<WalletResponse>($"/v2/wallets/{id}");
        }

        public static async Task<CardanoWallet?> GetWalletByNameAsync(string name)
        {
            var response = await HttpGetAsync<IEnumerable<WalletResponse>>("/v2/wallets");
            var walletResp = response.Where(w => w.Name == name).FirstOrDefault();
            return walletResp != null ? new CardanoWallet(walletResp) : null;
        }

        public static async Task<IEnumerable<WalletAddress>> GetWalletAddressesAsync(string id)
        {
            return await HttpGetAsync<IEnumerable<WalletAddress>>($"/v2/wallets/{id}/addresses");
        }

        public static async Task<string> GenerateAddressByWalletIdAsync(string id, string passphrase, long? index = null)
        {
            var result = await HttpPostJsonAsync<GenerateAddressResponse, GenerateAddressPayload>($"/v2/wallets/{id}/addresses", new GenerateAddressPayload
            {
                Passphrase = passphrase,
                AddressIndex = index
            });

            return result.Id;
        }

        public static async Task<string> CreateTransactionAsync(string walletId, string passphrase, IEnumerable<Payment> payments, object? metadata = null)
        {
            var result = await HttpPostJsonAsync<CreateTransactionResponse, CreateTransactionPayload>($"/v2/wallets/{walletId}/transactions", new CreateTransactionPayload
            {
                Payments = payments,
                Passphrase = passphrase,
                Metadata = CardanoTxSerializer.ToMetaDataPayload(metadata)
            });
            return result.Id;
        }

        public static async Task<long> EstimateTransactionFeeAsync(string walletId, IEnumerable<Payment> payments, object? metadata = null)
        {
            long result = 0;
            var pResult = await HttpPostJsonAsync<EstimateTransactionFeeResponse, EstimateTransactionFeePayload>($"/v2/wallets/{walletId}/payment-fees",
                new EstimateTransactionFeePayload
                {
                    Payments = payments,
                    Metadata = CardanoTxSerializer.ToMetaDataPayload(metadata)
                });

            if (pResult != null && pResult.EstimatedMaximum != null)
                result = pResult.EstimatedMaximum.Quantity;
            return result;
        }

        public static async Task<Transaction?> GetTransactionByIdAsync(string walletId, string txId)
        {
            return await HttpGetAsync<Transaction?>($"/v2/wallets/{walletId}/transactions/{txId}");
        }

        private static async Task<T> HttpGetAsync<T>(string url)
        {
            var resultString = await HttpClient.GetStringAsync($"{CardanoWalletEndpoint}{url}");
            return JsonConvert.DeserializeObject<T>(resultString);
        }

        private static async Task<R> HttpPostJsonAsync<R, P>(string url, P payload)
        {
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var result = await HttpClient.PostAsync($"{CardanoWalletEndpoint}{url}", new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
            var resultString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<R>(resultString);
        }

        public static long AdaToLovelace(decimal ada)
        {
            return (long)(ada * 1000000);
        }

        public static decimal LovelaceToAda(long? lovelace)
        {
            if (lovelace != null)
                return Math.Round(((decimal)lovelace / (decimal)1000000), 6);
            else
                return 0;
        }
    }
}
