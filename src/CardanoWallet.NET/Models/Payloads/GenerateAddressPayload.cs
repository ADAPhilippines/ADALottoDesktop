
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Payloads
{
    public class GenerateAddressPayload
    {

        [JsonProperty("passphrase")]
        public string Passphrase { get; set; } = string.Empty;

        [JsonProperty("address_index")]
        public long? AddressIndex { get; set; }
    }
}