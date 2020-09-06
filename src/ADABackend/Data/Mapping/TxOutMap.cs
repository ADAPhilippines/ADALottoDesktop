using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class TxOutMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.TxOut>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.TxOut> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("tx_out", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TxId)
                .IsRequired()
                .HasColumnName("tx_id")
                .HasColumnType("bigint");

            builder.Property(t => t.Index)
                .IsRequired()
                .HasColumnName("index")
                .HasColumnType("smallint");

            builder.Property(t => t.Address)
                .IsRequired()
                .HasColumnName("address")
                .HasColumnType("character varying");

            builder.Property(t => t.Value)
                .IsRequired()
                .HasColumnName("value")
                .HasColumnType("bigint");

            builder.Property(t => t.AddressRaw)
                .IsRequired()
                .HasColumnName("address_raw")
                .HasColumnType("bytea");

            builder.Property(t => t.PaymentCred)
                .HasColumnName("payment_cred")
                .HasColumnType("bytea");

            // relationships
            builder.HasOne(t => t.Tx)
                .WithMany(t => t.TxOuts)
                .HasForeignKey(d => d.TxId)
                .HasConstraintName("tx_out_tx_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "tx_out";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string TxId = "tx_id";
            public const string Index = "index";
            public const string Address = "address";
            public const string Value = "value";
            public const string AddressRaw = "address_raw";
            public const string PaymentCred = "payment_cred";
        }
        #endregion
    }
}
