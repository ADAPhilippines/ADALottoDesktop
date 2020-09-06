using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class Delegation
    {
        public Delegation()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public long AddrId { get; set; }

        public int CertIndex { get; set; }

        public long PoolHashId { get; set; }

        public long TxId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual StakeAddress AddrStakeAddress { get; set; }

        public virtual PoolHash PoolHash { get; set; }

        public virtual Tx Tx { get; set; }

        #endregion

    }
}
