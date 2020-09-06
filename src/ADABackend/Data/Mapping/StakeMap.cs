using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class StakeMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.Stake>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.Stake> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("stake", "public");

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

            builder.Property(t => t.TxId)
                .IsRequired()
                .HasColumnName("tx_id")
                .HasColumnType("bigint");

            builder.Property(t => t.StakeMember)
                .IsRequired()
                .HasColumnName("stake")
                .HasColumnType("bigint");

            // relationships
            builder.HasOne(t => t.AddrStakeAddress)
                .WithMany(t => t.AddrStakes)
                .HasForeignKey(d => d.AddrId)
                .HasConstraintName("stake_addr_id_fkey");

            builder.HasOne(t => t.Tx)
                .WithMany(t => t.Stakes)
                .HasForeignKey(d => d.TxId)
                .HasConstraintName("stake_tx_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "stake";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string AddrId = "addr_id";
            public const string TxId = "tx_id";
            public const string StakeMember = "stake";
        }
        #endregion
    }
}
