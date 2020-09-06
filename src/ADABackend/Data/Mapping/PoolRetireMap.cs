using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class PoolRetireMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.PoolRetire>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.PoolRetire> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("pool_retire", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.HashId)
                .IsRequired()
                .HasColumnName("hash_id")
                .HasColumnType("bigint");

            builder.Property(t => t.CertIndex)
                .IsRequired()
                .HasColumnName("cert_index")
                .HasColumnType("integer");

            builder.Property(t => t.AnnouncedTxId)
                .IsRequired()
                .HasColumnName("announced_tx_id")
                .HasColumnType("bigint");

            builder.Property(t => t.RetiringEpoch)
                .IsRequired()
                .HasColumnName("retiring_epoch")
                .HasColumnType("integer");

            // relationships
            builder.HasOne(t => t.AnnouncedTx)
                .WithMany(t => t.AnnouncedPoolRetires)
                .HasForeignKey(d => d.AnnouncedTxId)
                .HasConstraintName("pool_retire_announced_tx_id_fkey");

            builder.HasOne(t => t.HashPoolHash)
                .WithMany(t => t.HashPoolRetires)
                .HasForeignKey(d => d.HashId)
                .HasConstraintName("pool_retire_hash_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "pool_retire";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string HashId = "hash_id";
            public const string CertIndex = "cert_index";
            public const string AnnouncedTxId = "announced_tx_id";
            public const string RetiringEpoch = "retiring_epoch";
        }
        #endregion
    }
}
