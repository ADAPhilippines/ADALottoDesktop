
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class EstimateTransactionFeeResponse
    {
        [JsonProperty("estimated_min")]
        public BalanceData? EstimatedMinimum { get; set; }

        [JsonProperty("estimated_max")]
        public BalanceData? EstimatedMaximum { get; set; }
    }
}