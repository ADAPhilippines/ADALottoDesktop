using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class ParamUpdateCreateModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public int EpochNo { get; set; }

        public Byte[] Key { get; set; }

        public int? MinFeea { get; set; }

        public int? MinFeeb { get; set; }

        public int? MaxBlockSize { get; set; }

        public int? MaxTxSize { get; set; }

        public int? MaxBhSize { get; set; }

        public long? KeyDeposit { get; set; }

        public long? PoolDeposit { get; set; }

        public int? MaxEpoch { get; set; }

        public int? OptimalPoolCount { get; set; }

        public double? Influence { get; set; }

        public double? MonetaryExpandRate { get; set; }

        public double? TreasuryGrowthRate { get; set; }

        public double? Decentralisation { get; set; }

        public Byte[] Entropy { get; set; }

        public string ProtocolVersion { get; set; }

        public long? MinuTxoValue { get; set; }

        public long? MinPoolCost { get; set; }

        public long RegisteredTxId { get; set; }

        #endregion

    }
}
