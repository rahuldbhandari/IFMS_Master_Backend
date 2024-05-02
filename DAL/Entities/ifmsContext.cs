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

        public virtual DbSet<Ddo> Ddos { get; set; } = null!;
        public virtual DbSet<DetailHead> DetailHeads { get; set; } = null!;
        public virtual DbSet<MajorHead> MajorHeads { get; set; } = null!;
        public virtual DbSet<MinorHead> MinorHeads { get; set; } = null!;
        public virtual DbSet<SubDetailHead> SubDetailHeads { get; set; } = null!;
        public virtual DbSet<SubMajorHead> SubMajorHeads { get; set; } = null!;
        public virtual DbSet<Treasury> Treasuries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ddo>(entity =>
            {
                entity.ToTable("ddo", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.Code)
                    .HasMaxLength(9)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .HasColumnName("designation");

                entity.Property(e => e.DesignationMstId).HasColumnName("designation_mst_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone")
                    .IsFixedLength();

                entity.Property(e => e.TreasuryCode)
                    .HasMaxLength(3)
                    .HasColumnName("treasury_code")
                    .IsFixedLength();

                entity.Property(e => e.TreasuryMstId).HasColumnName("treasury_mst_id");
            });

            modelBuilder.Entity<DetailHead>(entity =>
            {
                entity.ToTable("detail_head", "master");

                entity.HasIndex(e => e.Code, "UK_detail_head")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

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

                entity.HasIndex(e => e.Code, "UK_minor_head")
                    .IsUnique();

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

            modelBuilder.Entity<SubDetailHead>(entity =>
            {
                entity.ToTable("sub_detail_head", "master");
                entity.HasIndex(e => e.Code, "UK_sub_detail_head")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.DetailHeadId).HasColumnName("detail_head_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

            });

            modelBuilder.Entity<SubMajorHead>(entity =>
            {
                entity.ToTable("sub_major_head", "master");

                entity.HasIndex(e => e.Code, "UK_sub_major_head")
                    .IsUnique();

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

            modelBuilder.Entity<Treasury>(entity =>
            {
                entity.ToTable("treasury", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.DistrictCode).HasColumnName("district_code");

                entity.Property(e => e.DistrictName)
                    .HasMaxLength(30)
                    .HasColumnName("district_name");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
