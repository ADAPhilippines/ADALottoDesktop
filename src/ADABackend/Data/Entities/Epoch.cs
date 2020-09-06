using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class Epoch
    {
        public Epoch()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public decimal OutSum { get; set; }

        public int TxCount { get; set; }

        public int BlkCount { get; set; }

        public int No { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
