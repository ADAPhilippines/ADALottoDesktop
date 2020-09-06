using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class TxMetadata
    {
        public TxMetadata()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public decimal Key { get; set; }

        public string Json { get; set; }

        public long TxId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Tx Tx { get; set; }

        #endregion

    }
}
