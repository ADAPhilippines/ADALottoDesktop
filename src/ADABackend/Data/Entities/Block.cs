using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class Block
    {
        public Block()
        {
            #region Generated Constructor
            PreviousBlocks = new HashSet<Block>();
            Txes = new HashSet<Tx>();
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public Byte[] Hash { get; set; }

        public int? EpochNo { get; set; }

        public int? SlotNo { get; set; }

        public int? BlockNo { get; set; }

        public long? Previous { get; set; }

        public Byte[] MerkelRoot { get; set; }

        public long SlotLeader { get; set; }

        public int Size { get; set; }

        public DateTime Time { get; set; }

        public long TxCount { get; set; }

        public int? EpochSlotNo { get; set; }

        public Byte[] VrfKey { get; set; }

        public Byte[] OpCert { get; set; }

        public string ProtoVersion { get; set; }

        #endregion

        #region Generated Relationships
        public virtual Block PreviousBlock { get; set; }

        public virtual ICollection<Block> PreviousBlocks { get; set; }

        public virtual SlotLeader SlotLeader1 { get; set; }

        public virtual ICollection<Tx> Txes { get; set; }

        #endregion

    }
}
