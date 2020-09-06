using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class EpochUpdateModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public decimal OutSum { get; set; }

        public int TxCount { get; set; }

        public int BlkCount { get; set; }

        public int No { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        #endregion

    }
}
