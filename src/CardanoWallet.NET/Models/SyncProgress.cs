using System;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("status")]
        public SyncStatus Status { get; set; }

        [JsonPropertyName("progress")]
        public ProgressData? Progress { get; set; }
    }
}