using System;

namespace ADALotto.Events
{
    public class ConfirmWithdrawalEventArgs : EventArgs
    {
        public long Fee { get; set; }
        public long Amount { get; set; }
    }
}