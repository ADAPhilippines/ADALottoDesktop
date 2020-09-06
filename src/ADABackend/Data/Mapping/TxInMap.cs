using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class TxInMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.TxIn>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.TxIn> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("tx_in", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TxInId)
                .IsRequired()
                .HasColumnName("tx_in_id")
                .HasColumnType("bigint");

            builder.Property(t => t.TxOutId)
                .IsRequired()
                .HasColumnName("tx_out_id")
                .HasColumnType("bigint");

            builder.Property(t => t.TxOutIndex)
                .IsRequired()
                .HasColumnName("tx_out_index")
                .HasColumnType("smallint");

            // relationships
            builder.HasOne(t => t.InTx)
                .WithMany(t => t.InTxIns)
                .HasForeignKey(d => d.TxInId)
                .HasConstraintName("tx_in_tx_in_id_fkey");

            builder.HasOne(t => t.OutTx)
                .WithMany(t => t.OutTxIns)
                .HasForeignKey(d => d.TxOutId)
                .HasConstraintName("tx_in_tx_out_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "tx_in";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string TxInId = "tx_in_id";
            public const string TxOutId = "tx_out_id";
            public const string TxOutIndex = "tx_out_index";
        }
        #endregion
    }
}
