
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models.Responses
{
    public class CreateTransactionResponse
    {

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public BalanceData? Amount { get; set; }
    }
}