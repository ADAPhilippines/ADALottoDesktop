using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public class WalletAddress
    {

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("state")]
        public WalletAddressState? State { get; set; }

    }
}