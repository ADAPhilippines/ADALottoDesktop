
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Payloads
{
    public class CreateTransactionPayload
    {
        [JsonProperty("payments")]
        public IEnumerable<Payment>? Payments { get; set; }

        [JsonProperty("passphrase")]
        public string Passphrase { get; set; } = string.Empty;

        [JsonProperty("metadata")]
        public string Metadata { get; set; } = string.Empty;
    }
}