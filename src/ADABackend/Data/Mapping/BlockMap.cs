using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class BlockMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.Block>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.Block> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("block", "public");

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

            builder.Property(t => t.EpochNo)
                .IsRequired(false)
                .HasColumnName("epoch_no")
                .HasColumnType("integer");

            builder.Property(t => t.SlotNo)
                .IsRequired(false)
                .HasColumnName("slot_no")
                .HasColumnType("integer");

            builder.Property(t => t.BlockNo)
                .HasColumnName("block_no")
                .HasColumnType("integer");

            builder.Property(t => t.Previous)
                .HasColumnName("previous")
                .HasColumnType("bigint");

            builder.Property(t => t.MerkelRoot)
                .IsRequired(false)
                .HasColumnName("merkel_root")
                .HasColumnType("bytea");

            builder.Property(t => t.SlotLeader)
                .IsRequired()
                .HasColumnName("slot_leader")
                .HasColumnType("bigint");

            builder.Property(t => t.Size)
                .IsRequired()
                .HasColumnName("size")
                .HasColumnType("integer");

            builder.Property(t => t.Time)
                .IsRequired()
                .HasColumnName("time")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.TxCount)
                .IsRequired()
                .HasColumnName("tx_count")
                .HasColumnType("bigint");

            builder.Property(t => t.EpochSlotNo)
                .HasColumnName("epoch_slot_no")
                .HasColumnType("integer");

            builder.Property(t => t.VrfKey)
                .IsRequired(false)
                .HasColumnName("vrf_key")
                .HasColumnType("bytea");

            builder.Property(t => t.OpCert)
                .IsRequired(false)
                .HasColumnName("op_cert")
                .HasColumnType("bytea");

            builder.Property(t => t.ProtoVersion)
                .IsRequired(false)
                .HasColumnName("proto_version")
                .HasColumnType("character varying");

            // relationships
            builder.HasOne(t => t.PreviousBlock)
                .WithMany(t => t.PreviousBlocks)
                .HasForeignKey(d => d.Previous)
                .HasConstraintName("block_previous_fkey");

            builder.HasOne(t => t.SlotLeader1)
                .WithMany(t => t.Blocks)
                .HasForeignKey(d => d.SlotLeader)
                .HasConstraintName("block_slot_leader_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "block";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string Hash = "hash";
            public const string EpochNo = "epoch_no";
            public const string SlotNo = "slot_no";
            public const string BlockNo = "block_no";
            public const string Previous = "previous";
            public const string MerkelRoot = "merkel_root";
            public const string SlotLeader = "slot_leader";
            public const string Size = "size";
            public const string Time = "time";
            public const string TxCount = "tx_count";
            public const string EpochSlotNo = "epoch_slot_no";
            public const string VrfKey = "vrf_key";
            public const string OpCert = "op_cert";
            public const string ProtoVersion = "proto_version";
        }
        #endregion
    }
}
