using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IFMS_Master_Backend.DAL.Entities
{
    public partial class ifmsContext : DbContext
    {
        public ifmsContext()
        {
        }

        public ifmsContext(DbContextOptions<ifmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MajorHead> MajorHeads { get; set; } = null!;
        public virtual DbSet<MinorHead> MinorHeads { get; set; } = null!;
        public virtual DbSet<SubMajorHead> SubMajorHeads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MajorHead>(entity =>
            {
                entity.ToTable("major_head", "master");

                entity.HasIndex(e => e.Code, "UK_major_head")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(4)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MinorHead>(entity =>
            {
                entity.ToTable("minor_head", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.SubMajorId).HasColumnName("sub_major_id");
            });

            modelBuilder.Entity<SubMajorHead>(entity =>
            {
                entity.ToTable("sub_major_head", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.MajorHeadId).HasColumnName("major_head_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
