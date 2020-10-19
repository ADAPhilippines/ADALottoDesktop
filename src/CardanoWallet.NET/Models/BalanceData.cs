using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public enum BalanceUnit
    {
        Unknown,
        Lovelace
    }
    public class BalanceData
    {
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("unit")]
        public BalanceUnit Unit { get; set; }
    }
}