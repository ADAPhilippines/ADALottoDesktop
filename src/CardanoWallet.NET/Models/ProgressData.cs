using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public enum ProgressUnitType
    {
        Unknown,
        Percent
    }

    public class ProgressData
    {
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        [JsonPropertyName("unit")]
        public ProgressUnitType Unit { get; set; }
    }
}