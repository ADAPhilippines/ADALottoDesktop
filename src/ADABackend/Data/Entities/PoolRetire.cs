using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class PoolRetire
    {
        public PoolRetire()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public long HashId { get; set; }

        public int CertIndex { get; set; }

        public long AnnouncedTxId { get; set; }

        public int RetiringEpoch { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Tx AnnouncedTx { get; set; }

        public virtual PoolHash HashPoolHash { get; set; }

        #endregion

    }
}
