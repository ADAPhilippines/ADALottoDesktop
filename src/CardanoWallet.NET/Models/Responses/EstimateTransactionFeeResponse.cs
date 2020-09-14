
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class EstimateTransactionFeeResponse
    {
        [JsonPropertyName("amount")]
        public BalanceData? Amount { get; set; }
    }
}