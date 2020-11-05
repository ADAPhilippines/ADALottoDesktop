using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SAIB.CardanoWallet.NET.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionStatus
    {
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "in_ledger")]
        InLedger,
        [EnumMember(Value = "expired")]
        Expired
    }

    public class Transaction
    {
        public string Id { get; set; } = string.Empty;
        public TransactionStatus Status { get; set; } = TransactionStatus.Unknown;
    }
}