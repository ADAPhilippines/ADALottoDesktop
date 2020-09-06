using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class StakeAddressMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.StakeAddress>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.StakeAddress> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("stake_address", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.HashRaw)
                .IsRequired()
                .HasColumnName("hash_raw")
                .HasColumnType("bytea");

            builder.Property(t => t.View)
                .IsRequired()
                .HasColumnName("view")
                .HasColumnType("character varying");

            builder.Property(t => t.RegisteredTxId)
                .IsRequired()
                .HasColumnName("registered_tx_id")
                .HasColumnType("bigint");

            // relationships
            builder.HasOne(t => t.RegisteredTx)
                .WithMany(t => t.RegisteredStakeAddresses)
                .HasForeignKey(d => d.RegisteredTxId)
                .HasConstraintName("stake_address_registered_tx_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "stake_address";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string HashRaw = "hash_raw";
            public const string View = "view";
            public const string RegisteredTxId = "registered_tx_id";
        }
        #endregion
    }
}
