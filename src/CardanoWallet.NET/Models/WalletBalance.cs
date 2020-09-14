using System;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models
{
    public class WalletBalance
    {

        [JsonPropertyName("available")]
        public BalanceData? Available { get; set; }

        [JsonPropertyName("total")]
        public BalanceData? Total { get; set; }
    }
}