
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models.Payloads
{
    public class EstimateTransactionFeePayload
    {
        [JsonPropertyName("payments")]
        public IEnumerable<Payment>? Payments { get; set; }
    }
}