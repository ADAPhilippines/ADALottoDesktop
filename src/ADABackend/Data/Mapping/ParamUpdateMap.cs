using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class ParamUpdateMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.ParamUpdate>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.ParamUpdate> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("param_update", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.EpochNo)
                .IsRequired()
                .HasColumnName("epoch_no")
                .HasColumnType("integer");

            builder.Property(t => t.Key)
                .IsRequired()
                .HasColumnName("key")
                .HasColumnType("bytea");

            builder.Property(t => t.MinFeea)
                .HasColumnName("min_fee_a")
                .HasColumnType("integer");

            builder.Property(t => t.MinFeeb)
                .HasColumnName("min_fee_b")
                .HasColumnType("integer");

            builder.Property(t => t.MaxBlockSize)
                .HasColumnName("max_block_size")
                .HasColumnType("integer");

            builder.Property(t => t.MaxTxSize)
                .HasColumnName("max_tx_size")
                .HasColumnType("integer");

            builder.Property(t => t.MaxBhSize)
                .HasColumnName("max_bh_size")
                .HasColumnType("integer");

            builder.Property(t => t.KeyDeposit)
                .HasColumnName("key_deposit")
                .HasColumnType("bigint");

            builder.Property(t => t.PoolDeposit)
                .HasColumnName("pool_deposit")
                .HasColumnType("bigint");

            builder.Property(t => t.MaxEpoch)
                .HasColumnName("max_epoch")
                .HasColumnType("integer");

            builder.Property(t => t.OptimalPoolCount)
                .HasColumnName("optimal_pool_count")
                .HasColumnType("integer");

            builder.Property(t => t.Influence)
                .HasColumnName("influence")
                .HasColumnType("double precision");

            builder.Property(t => t.MonetaryExpandRate)
                .HasColumnName("monetary_expand_rate")
                .HasColumnType("double precision");

            builder.Property(t => t.TreasuryGrowthRate)
                .HasColumnName("treasury_growth_rate")
                .HasColumnType("double precision");

            builder.Property(t => t.Decentralisation)
                .HasColumnName("decentralisation")
                .HasColumnType("double precision");

            builder.Property(t => t.Entropy)
                .HasColumnName("entropy")
                .HasColumnType("bytea");

            builder.Property(t => t.ProtocolVersion)
                .HasColumnName("protocol_version")
                .HasColumnType("character varying");

            builder.Property(t => t.MinuTxoValue)
                .HasColumnName("min_u_tx_o_value")
                .HasColumnType("bigint");

            builder.Property(t => t.MinPoolCost)
                .HasColumnName("min_pool_cost")
                .HasColumnType("bigint");

            builder.Property(t => t.RegisteredTxId)
                .IsRequired()
                .HasColumnName("registered_tx_id")
                .HasColumnType("bigint");

            // relationships
            builder.HasOne(t => t.RegisteredTx)
                .WithMany(t => t.RegisteredParamUpdates)
                .HasForeignKey(d => d.RegisteredTxId)
                .HasConstraintName("param_update_registered_tx_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "param_update";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string EpochNo = "epoch_no";
            public const string Key = "key";
            public const string MinFeea = "min_fee_a";
            public const string MinFeeb = "min_fee_b";
            public const string MaxBlockSize = "max_block_size";
            public const string MaxTxSize = "max_tx_size";
            public const string MaxBhSize = "max_bh_size";
            public const string KeyDeposit = "key_deposit";
            public const string PoolDeposit = "pool_deposit";
            public const string MaxEpoch = "max_epoch";
            public const string OptimalPoolCount = "optimal_pool_count";
            public const string Influence = "influence";
            public const string MonetaryExpandRate = "monetary_expand_rate";
            public const string TreasuryGrowthRate = "treasury_growth_rate";
            public const string Decentralisation = "decentralisation";
            public const string Entropy = "entropy";
            public const string ProtocolVersion = "protocol_version";
            public const string MinuTxoValue = "min_u_tx_o_value";
            public const string MinPoolCost = "min_pool_cost";
            public const string RegisteredTxId = "registered_tx_id";
        }
        #endregion
    }
}
