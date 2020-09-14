
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class GenerateAddressResponse
    {

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public WalletAddressState State { get; set; }
    }
}