using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class StakeAddressReadModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public Byte[] HashRaw { get; set; }

        public string View { get; set; }

        public long RegisteredTxId { get; set; }

        #endregion

    }
}
