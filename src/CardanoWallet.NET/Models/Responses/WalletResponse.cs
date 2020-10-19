using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class WalletResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("balance")]
        public WalletBalance? Balance { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("state")]
        public WalletState? State { get; set; }

        [JsonProperty("tip")]
        public Tip? Tip { get; set; }
    }
}