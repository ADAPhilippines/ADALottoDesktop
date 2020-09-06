using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class TxMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.Tx>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.Tx> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("tx", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Hash)
                .IsRequired()
                .HasColumnName("hash")
                .HasColumnType("bytea");

            builder.Property(t => t.Block)
                .IsRequired()
                .HasColumnName("block")
                .HasColumnType("bigint");

            builder.Property(t => t.BlockIndex)
                .IsRequired()
                .HasColumnName("block_index")
                .HasColumnType("integer");

            builder.Property(t => t.OutSum)
                .IsRequired()
                .HasColumnName("out_sum")
                .HasColumnType("bigint");

            builder.Property(t => t.Fee)
                .IsRequired()
                .HasColumnName("fee")
                .HasColumnType("bigint");

            builder.Property(t => t.Size)
                .IsRequired()
                .HasColumnName("size")
                .HasColumnType("integer");

            builder.Property(t => t.Deposit)
                .IsRequired()
                .HasColumnName("deposit")
                .HasColumnType("bigint");

            // relationships
            builder.HasOne(t => t.Block1)
                .WithMany(t => t.Txes)
                .HasForeignKey(d => d.Block)
                .HasConstraintName("tx_block_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "tx";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string Hash = "hash";
            public const string Block = "block";
            public const string BlockIndex = "block_index";
            public const string OutSum = "out_sum";
            public const string Fee = "fee";
            public const string Size = "size";
            public const string Deposit = "deposit";
        }
        #endregion
    }
}
