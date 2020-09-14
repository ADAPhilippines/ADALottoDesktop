
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SAIB.CardanoWallet.NET.Models.Payloads
{
    public class CreateTransactionPayload
    {
        [JsonPropertyName("payments")]
        public IEnumerable<Payment>? Payments { get; set; }

        [JsonPropertyName("passphrase")]
        public string Passphrase { get; set; } = string.Empty;
    }
}