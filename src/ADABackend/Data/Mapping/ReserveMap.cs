using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class ReserveMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.Reserve>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.Reserve> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("reserve", "public");

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

            builder.Property(t => t.Amount)
                .IsRequired()
                .HasColumnName("amount")
                .HasColumnType("bigint");

            builder.Property(t => t.TxId)
                .IsRequired()
                .HasColumnName("tx_id")
                .HasColumnType("bigint");

            // relationships
            builder.HasOne(t => t.AddrStakeAddress)
                .WithMany(t => t.AddrReserves)
                .HasForeignKey(d => d.AddrId)
                .HasConstraintName("reserve_addr_id_fkey");

            builder.HasOne(t => t.Tx)
                .WithMany(t => t.Reserves)
                .HasForeignKey(d => d.TxId)
                .HasConstraintName("reserve_tx_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "reserve";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string AddrId = "addr_id";
            public const string CertIndex = "cert_index";
            public const string Amount = "amount";
            public const string TxId = "tx_id";
        }
        #endregion
    }
}
