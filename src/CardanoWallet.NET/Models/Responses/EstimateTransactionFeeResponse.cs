
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class EstimateTransactionFeeResponse
    {
        [JsonProperty("amount")]
        public BalanceData? Amount { get; set; }
    }
}