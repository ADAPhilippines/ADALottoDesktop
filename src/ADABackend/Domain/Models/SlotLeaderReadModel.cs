using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class SlotLeaderReadModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public Byte[] Hash { get; set; }

        public string Description { get; set; }

        public long? PoolHashId { get; set; }

        #endregion

    }
}
