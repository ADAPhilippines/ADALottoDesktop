using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Mapping
{
    public partial class SchemaVersionMap
        : IEntityTypeConfiguration<Cardano.Data.Entities.SchemaVersion>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cardano.Data.Entities.SchemaVersion> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("schema_version", "public");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.StageOne)
                .IsRequired()
                .HasColumnName("stage_one")
                .HasColumnType("bigint");

            builder.Property(t => t.StageTwo)
                .IsRequired()
                .HasColumnName("stage_two")
                .HasColumnType("bigint");

            builder.Property(t => t.StageThree)
                .IsRequired()
                .HasColumnName("stage_three")
                .HasColumnType("bigint");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "schema_version";
        }

        public struct Columns
        {
            public const string Id = "id";
            public const string StageOne = "stage_one";
            public const string StageTwo = "stage_two";
            public const string StageThree = "stage_three";
        }
        #endregion
    }
}
