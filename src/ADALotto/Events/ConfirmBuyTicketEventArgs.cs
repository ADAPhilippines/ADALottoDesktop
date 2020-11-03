using System;

namespace ADALotto.Events
{
    public class ConfirmBuyTicketEventArgs : EventArgs
    {
        public int[]? Combination { get; set; }
        public long Fee { get; set; }
        public long Price { get; set; }
    }
}