using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class PoolRelay
    {
        public PoolRelay()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public long UpdateId { get; set; }

        public string Ipv4 { get; set; }

        public string Ipv6 { get; set; }

        public string DnsName { get; set; }

        public string DnsSrvName { get; set; }

        public int? Port { get; set; }

        #endregion

        #region Generated Relationships
        public virtual PoolUpdate UpdatePoolUpdate { get; set; }

        #endregion

    }
}
