using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class PoolOwnerMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.PoolOwner>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.PoolOwner> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("pool_owner", "public");

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

            builder.Property(t => t.PoolHashId)
                .IsRequired()
                .HasColumnName("pool_hash_id")
                .HasColumnType("bigint");

            // relationships
            builder.HasOne(t => t.PoolHash)
                .WithMany(t => t.PoolOwners)
                .HasForeignKey(d => d.PoolHashId)
                .HasConstraintName("pool_owner_pool_hash_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "pool_owner";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string Hash = "hash";
            public const string PoolHashId = "pool_hash_id";
        }
        #endregion
    }
}
