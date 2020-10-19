using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public class Payment
    {
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public BalanceData? Amount { get; set; }
    }
}