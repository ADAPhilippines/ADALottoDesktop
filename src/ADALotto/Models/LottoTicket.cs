using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ADALotto.Models
{
    public class LottoTicket
    {
        public int Type { get; set; } = 2;
        public IEnumerable<int>? Combination { get; set; }
    }
}
