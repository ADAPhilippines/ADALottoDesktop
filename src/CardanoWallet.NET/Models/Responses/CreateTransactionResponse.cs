
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class CreateTransactionResponse
    {

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public BalanceData? Amount { get; set; }
    }
}