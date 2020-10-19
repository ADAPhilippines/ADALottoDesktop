using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public class Tip
    {
        [JsonProperty("epoch_number")]
        public long Epoch { get; set; }

        [JsonProperty("slot_number")]
        public long Slot { get; set; }

        [JsonProperty("height")]
        public Height? Height { get; set; }
    }
}
