using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class SlotLeader
    {
        public SlotLeader()
        {
            #region Generated Constructor
            Blocks = new HashSet<Block>();
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public Byte[] Hash { get; set; }

        public string Description { get; set; }

        public long? PoolHashId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<Block> Blocks { get; set; }

        #endregion

    }
}
