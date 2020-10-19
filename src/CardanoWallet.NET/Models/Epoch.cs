using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public class Epoch
    {

        [JsonProperty("epoch_start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("epoch_number")]
        public long Number { get; set; }
    }
}