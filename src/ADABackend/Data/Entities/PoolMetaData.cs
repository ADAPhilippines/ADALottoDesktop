using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class PoolMetaData
    {
        public PoolMetaData()
        {
            #region Generated Constructor
            MetaPoolUpdates = new HashSet<PoolUpdate>();
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public string Url { get; set; }

        public Byte[] Hash { get; set; }

        public long RegisteredTxId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<PoolUpdate> MetaPoolUpdates { get; set; }

        public virtual Tx RegisteredTx { get; set; }

        #endregion

    }
}
