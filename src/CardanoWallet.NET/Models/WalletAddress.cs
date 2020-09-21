using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public class WalletAddress
    {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("state")]
        public WalletAddressState? State { get; set; }

    }
}