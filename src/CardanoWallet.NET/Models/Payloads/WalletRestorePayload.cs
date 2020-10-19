
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Payloads
{
    public class WalletRestorePayload
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("passphrase")]
        public string Passphrase { get; set; } = string.Empty;

        [JsonProperty("mnemonic_sentence")]
        public string[]? MnemonicSeed { get; set; }
    }
}