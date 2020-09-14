
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class WalletResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("balance")]
        public WalletBalance? Balance { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public WalletState? State { get; set; }

        [JsonPropertyName("tip")]
        public Tip? Tip { get; set; }
    }
}