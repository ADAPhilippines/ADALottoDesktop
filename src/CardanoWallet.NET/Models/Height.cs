using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public enum HeightUnit
    {
        Unknown,
        Block
    }
    public class Height
    {
        [JsonPropertyName("quantity")]
        public long Quantity { get; set; }

        [JsonPropertyName("unit")]
        public HeightUnit Unit { get; set; }
    }
}
