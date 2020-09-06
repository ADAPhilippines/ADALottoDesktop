using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class MetaMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.Meta>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.Meta> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("meta", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.StartTime)
                .IsRequired()
                .HasColumnName("start_time")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.NetworkName)
                .IsRequired()
                .HasColumnName("network_name")
                .HasColumnType("character varying");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "meta";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string StartTime = "start_time";
            public const string NetworkName = "network_name";
        }
        #endregion
    }
}
