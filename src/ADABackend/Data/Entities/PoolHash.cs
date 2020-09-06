using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class PoolHash
    {
        public PoolHash()
        {
            #region Generated Constructor
            Delegations = new HashSet<Delegation>();
            HashPoolRetires = new HashSet<PoolRetire>();
            HashPoolUpdates = new HashSet<PoolUpdate>();
            PoolOwners = new HashSet<PoolOwner>();
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public Byte[] Hash { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Delegation> Delegations { get; set; }

        public virtual ICollection<PoolRetire> HashPoolRetires { get; set; }

        public virtual ICollection<PoolUpdate> HashPoolUpdates { get; set; }

        public virtual ICollection<PoolOwner> PoolOwners { get; set; }

        #endregion

    }
}
