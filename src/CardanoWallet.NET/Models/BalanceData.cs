using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public enum BalanceUnit
    {
        Unknown,
        Lovelace
    }
    public class BalanceData
    {
        [JsonPropertyName("quantity")]
        public long Quantity { get; set; }

        [JsonPropertyName("unit")]
        public BalanceUnit Unit { get; set; }
    }
}