using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SAIB.CardanoWallet.NET.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BalanceUnit
    {
        [EnumMember(Value="unknown")]
        Unknown,
        [EnumMember(Value="lovelace")]
        Lovelace
    }
    
    public class BalanceData
    {
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("unit")]
        public BalanceUnit Unit { get; set; }
    }
}