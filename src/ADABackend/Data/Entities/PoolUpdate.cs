using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class PoolUpdate
    {
        public PoolUpdate()
        {
            #region Generated Constructor
            UpdatePoolRelays = new HashSet<PoolRelay>();
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public long HashId { get; set; }

        public int CertIndex { get; set; }

        public Byte[] VrfKey { get; set; }

        public decimal Pledge { get; set; }

        public long RewardAddrId { get; set; }

        public long? Meta { get; set; }

        public double Margin { get; set; }

        public long FixedCost { get; set; }

        public long RegisteredTxId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual PoolHash HashPoolHash { get; set; }

        public virtual PoolMetaData MetaPoolMetaData { get; set; }

        public virtual Tx RegisteredTx { get; set; }

        public virtual StakeAddress RewardAddrStakeAddress { get; set; }

        public virtual ICollection<PoolRelay> UpdatePoolRelays { get; set; }

        #endregion

    }
}
