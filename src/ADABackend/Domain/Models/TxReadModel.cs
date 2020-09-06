using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class TxReadModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public Byte[] Hash { get; set; }

        public long Block { get; set; }

        public int BlockIndex { get; set; }

        public long OutSum { get; set; }

        public long Fee { get; set; }

        public int Size { get; set; }

        public long Deposit { get; set; }

        #endregion

    }
}
