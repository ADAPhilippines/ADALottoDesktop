using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class PoolMetaDataMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.PoolMetaData>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.PoolMetaData> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("pool_meta_data", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Url)
                .IsRequired()
                .HasColumnName("url")
                .HasColumnType("character varying");

            builder.Property(t => t.Hash)
                .IsRequired()
                .HasColumnName("hash")
                .HasColumnType("bytea");

            builder.Property(t => t.RegisteredTxId)
                .IsRequired()
                .HasColumnName("registered_tx_id")
                .HasColumnType("bigint");

            // relationships
            builder.HasOne(t => t.RegisteredTx)
                .WithMany(t => t.RegisteredPoolMetaData)
                .HasForeignKey(d => d.RegisteredTxId)
                .HasConstraintName("pool_meta_data_registered_tx_id_fkey");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "pool_meta_data";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string Url = "url";
            public const string Hash = "hash";
            public const string RegisteredTxId = "registered_tx_id";
        }
        #endregion
    }
}
