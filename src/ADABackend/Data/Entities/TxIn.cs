using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class TxIn
    {
        public TxIn()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public long TxInId { get; set; }

        public long TxOutId { get; set; }

        public short TxOutIndex { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Tx InTx { get; set; }

        public virtual Tx OutTx { get; set; }

        #endregion

    }
}
