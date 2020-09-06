using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class PoolMetaDataCreateModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public string Url { get; set; }

        public Byte[] Hash { get; set; }

        public long RegisteredTxId { get; set; }

        #endregion

    }
}
