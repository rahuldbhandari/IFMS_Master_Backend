using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IFMS_Master_Backend.DAL.Entities;

namespace IFMS_Master_Backend.DAL
{
    public partial class IfmsDBContext : DbContext
    {
        public IfmsDBContext()
        {
        }

        public IfmsDBContext(DbContextOptions<IfmsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ddo> Ddos { get; set; } = null!;
        public virtual DbSet<Treasury> Treasuries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=ifms;Username=postgres;Password=postgres");
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

                entity.Property(e => e.IsDelete).HasDefaultValueSql("false");

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

                entity.Property(e => e.IsDelete).HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
