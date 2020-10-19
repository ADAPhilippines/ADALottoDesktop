using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public class WalletState
    {
        [JsonProperty("status")]
        public WalletStatus Status { get; set; }

        [JsonProperty("progress")]
        public ProgressData? Progress { get; set; }
    }
}