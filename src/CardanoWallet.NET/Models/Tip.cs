using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public class Tip
    {
        [JsonPropertyName("epoch_number")]
        public long Epoch { get; set; }

        [JsonPropertyName("slot_number")]
        public long Slot { get; set; }

        [JsonPropertyName("height")]
        public Height? Height { get; set; }
    }
}
