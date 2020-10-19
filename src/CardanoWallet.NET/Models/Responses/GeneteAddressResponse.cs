using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class GenerateAddressResponse
    {

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("state")]
        public WalletAddressState State { get; set; }
    }
}