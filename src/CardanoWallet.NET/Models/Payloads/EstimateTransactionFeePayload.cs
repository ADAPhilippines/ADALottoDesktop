
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Payloads
{
    public class EstimateTransactionFeePayload
    {
        [JsonProperty("payments")]
        public IEnumerable<Payment>? Payments { get; set; }

        [JsonProperty("metadata")]
        public object? Metadata { get; set; } = string.Empty;
    }
}