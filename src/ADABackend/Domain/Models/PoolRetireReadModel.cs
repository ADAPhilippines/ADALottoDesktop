using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class PoolRetireReadModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public long HashId { get; set; }

        public int CertIndex { get; set; }

        public long AnnouncedTxId { get; set; }

        public int RetiringEpoch { get; set; }

        #endregion

    }
}
