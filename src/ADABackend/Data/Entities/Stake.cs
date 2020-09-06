using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class Stake
    {
        public Stake()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public long AddrId { get; set; }

        public long TxId { get; set; }

        public long StakeMember { get; set; }

        #endregion

        #region Generated Relationships
        public virtual StakeAddress AddrStakeAddress { get; set; }

        public virtual Tx Tx { get; set; }

        #endregion

    }
}
