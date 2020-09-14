using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public class Epoch
    {

        [JsonPropertyName("epoch_start_time")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("epoch_number")]
        public long Number { get; set; }
    }
}