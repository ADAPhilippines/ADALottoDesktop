using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class EpochMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.Epoch>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.Epoch> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("epoch", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.OutSum)
                .IsRequired()
                .HasColumnName("out_sum")
                .HasColumnType("numeric(38,0)");

            builder.Property(t => t.TxCount)
                .IsRequired()
                .HasColumnName("tx_count")
                .HasColumnType("integer");

            builder.Property(t => t.BlkCount)
                .IsRequired()
                .HasColumnName("blk_count")
                .HasColumnType("integer");

            builder.Property(t => t.No)
                .IsRequired()
                .HasColumnName("no")
                .HasColumnType("integer");

            builder.Property(t => t.StartTime)
                .IsRequired()
                .HasColumnName("start_time")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.EndTime)
                .IsRequired()
                .HasColumnName("end_time")
                .HasColumnType("timestamp without time zone");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "epoch";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string OutSum = "out_sum";
            public const string TxCount = "tx_count";
            public const string BlkCount = "blk_count";
            public const string No = "no";
            public const string StartTime = "start_time";
            public const string EndTime = "end_time";
        }
        #endregion
    }
}
