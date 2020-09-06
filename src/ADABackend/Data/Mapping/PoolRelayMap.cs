using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class PoolRelayMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.PoolRelay>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.PoolRelay> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("pool_relay", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UpdateId)
                .IsRequired()
                .HasColumnName("update_id")
                .HasColumnType("bigint");

            builder.Property(t => t.Ipv4)
                .HasColumnName("ipv4")
                .HasColumnType("character varying");

            builder.Property(t => t.Ipv6)
                .HasColumnName("ipv6")
                .HasColumnType("character varying");

            builder.Property(t => t.DnsName)
                .HasColumnName("dns_name")
                .HasColumnType("character varying");

            builder.Property(t => t.DnsSrvName)
                .HasColumnName("dns_srv_name")
                .HasColumnType("character varying");

            builder.Property(t => t.Port)
                .HasColumnName("port")
                .HasColumnType("integer");

            // relationships
            builder.HasOne(t => t.UpdatePoolUpdate)
                .WithMany(t => t.UpdatePoolRelays)
                .HasForeignKey(d => d.UpdateId)
                .HasConstraintName("pool_relay_update_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "pool_relay";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string UpdateId = "update_id";
            public const string Ipv4 = "ipv4";
            public const string Ipv6 = "ipv6";
            public const string DnsName = "dns_name";
            public const string DnsSrvName = "dns_srv_name";
            public const string Port = "port";
        }
        #endregion
    }
}
