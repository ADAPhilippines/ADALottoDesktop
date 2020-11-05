using System;

namespace ADALotto.Events
{
    public class LoadingStartEventArgs : EventArgs
    {
		public string Message { get; set; } = string.Empty;
    }
}