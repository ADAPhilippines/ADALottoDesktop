using System;
using System.Collections.Generic;

namespace Cardano.Domain.Models
{
    public partial class PoolRelayCreateModel
    {
        #region Generated Properties
        public long Id { get; set; }

        public long UpdateId { get; set; }

        public string Ipv4 { get; set; }

        public string Ipv6 { get; set; }

        public string DnsName { get; set; }

        public string DnsSrvName { get; set; }

        public int? Port { get; set; }

        #endregion

    }
}
