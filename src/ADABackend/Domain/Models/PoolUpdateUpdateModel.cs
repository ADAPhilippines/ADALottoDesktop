using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class PoolUpdateUpdateModel
    {
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

    }
}
