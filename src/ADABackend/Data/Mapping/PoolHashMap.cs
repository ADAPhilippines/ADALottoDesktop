using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class PoolHashMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.PoolHash>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.PoolHash> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("pool_hash", "public");

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

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "pool_hash";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string Hash = "hash";
        }
        #endregion
    }
}
