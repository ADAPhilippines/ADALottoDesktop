using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class TxInReadModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public long TxInId { get; set; }

        public long TxOutId { get; set; }

        public short TxOutIndex { get; set; }

        #endregion

    }
}
