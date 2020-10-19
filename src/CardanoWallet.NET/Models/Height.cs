using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public enum HeightUnit
    {
        Unknown,
        Block
    }
    public class Height
    {
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("unit")]
        public HeightUnit Unit { get; set; }
    }
}
