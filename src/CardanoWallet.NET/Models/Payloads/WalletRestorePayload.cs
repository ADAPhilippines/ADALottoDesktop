
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models.Payloads
{
    public class WalletRestorePayload
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("passphrase")]
        public string Passphrase { get; set; } = string.Empty;

        [JsonPropertyName("mnemonic_sentence")]
        public string[]? MnemonicSeed { get; set; }
    }
}