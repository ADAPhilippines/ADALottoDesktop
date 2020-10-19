using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public class NetworkInfo
    {
        [JsonProperty("network_tip")]
        public Tip? NetworkTip { get; set; }

        [JsonProperty("node_tip")]
        public Tip? NodeTip { get; set; }

        [JsonProperty("sync_progress")]
        public SyncProgress? SyncProgress { get; set; }

        [JsonProperty("next_epoch")]
        public Epoch? NextEpoch { get; set; }
    }
}