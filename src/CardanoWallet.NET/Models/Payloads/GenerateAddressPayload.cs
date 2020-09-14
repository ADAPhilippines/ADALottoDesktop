
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models.Payloads
{
    public class GenerateAddressPayload
    {

        [JsonPropertyName("passphrase")]
        public string Passphrase { get; set; } = string.Empty;

        [JsonPropertyName("address_index")]
        public long? AddressIndex { get; set; }
    }
}