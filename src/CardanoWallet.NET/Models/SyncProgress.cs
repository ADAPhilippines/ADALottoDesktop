using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public enum SyncStatus
    {
        Unknown,
        Ready,
        Syncing
    }

    public class SyncProgress
    {
        [JsonProperty("status")]
        public SyncStatus Status { get; set; }

        [JsonProperty("progress")]
        public ProgressData? Progress { get; set; }
    }
}