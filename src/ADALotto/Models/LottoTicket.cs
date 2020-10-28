using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ADALotto.Models
{
    public class LottoTicket
    {
        public IEnumerable<int>? Combination { get; set; }
    }
}
