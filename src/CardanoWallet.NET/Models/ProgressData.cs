using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public enum ProgressUnitType
    {
        Unknown,
        Percent
    }

    public class ProgressData
    {
        [JsonProperty("quantity")]
        public float Quantity { get; set; }

        [JsonProperty("unit")]
        public ProgressUnitType Unit { get; set; }
    }
}