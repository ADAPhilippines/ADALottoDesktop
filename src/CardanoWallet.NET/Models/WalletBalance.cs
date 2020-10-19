using System;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Models
{
    public class WalletBalance
    {

        [JsonProperty("available")]
        public BalanceData? Available { get; set; }

        [JsonProperty("total")]
        public BalanceData? Total { get; set; }
    }
}