using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public class WalletState
    {
        [JsonPropertyName("status")]
        public WalletStatus Status { get; set; }

        [JsonPropertyName("progress")]
        public ProgressData? Progress { get; set; }
    }
}