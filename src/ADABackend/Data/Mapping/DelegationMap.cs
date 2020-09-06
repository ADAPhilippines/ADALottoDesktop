using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class DelegationMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.Delegation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.Delegation> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("delegation", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.AddrId)
                .IsRequired()
                .HasColumnName("addr_id")
                .HasColumnType("bigint");

            builder.Property(t => t.CertIndex)
                .IsRequired()
                .HasColumnName("cert_index")
                .HasColumnType("integer");

            builder.Property(t => t.PoolHashId)
                .IsRequired()
                .HasColumnName("pool_hash_id")
                .HasColumnType("bigint");

            builder.Property(t => t.TxId)
                .IsRequired()
                .HasColumnName("tx_id")
                .HasColumnType("bigint");

            // relationships
            builder.HasOne(t => t.AddrStakeAddress)
                .WithMany(t => t.AddrDelegations)
                .HasForeignKey(d => d.AddrId)
                .HasConstraintName("delegation_addr_id_fkey");

            builder.HasOne(t => t.PoolHash)
                .WithMany(t => t.Delegations)
                .HasForeignKey(d => d.PoolHashId)
                .HasConstraintName("delegation_pool_hash_id_fkey");

            builder.HasOne(t => t.Tx)
                .WithMany(t => t.Delegations)
                .HasForeignKey(d => d.TxId)
                .HasConstraintName("delegation_tx_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "delegation";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string AddrId = "addr_id";
            public const string CertIndex = "cert_index";
            public const string PoolHashId = "pool_hash_id";
            public const string TxId = "tx_id";
        }
        #endregion
    }
}
