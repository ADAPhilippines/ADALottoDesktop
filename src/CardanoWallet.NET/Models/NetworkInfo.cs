using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public class NetworkInfo
    {
        [JsonPropertyName("network_tip")]
        public Tip? NetworkTip { get; set; }

        [JsonPropertyName("node_tip")]
        public Tip? NodeTip { get; set; }

        [JsonPropertyName("sync_progress")]
        public SyncProgress? SyncProgress { get; set; }

        [JsonPropertyName("next_epoch")]
        public Epoch? NextEpoch { get; set; }
    }
}