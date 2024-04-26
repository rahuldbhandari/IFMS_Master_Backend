using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IFMS_Master_Backend.DAL.Entities
{
    public partial class IfmsContext : DbContext
    {
        public IfmsContext()
        {
        }

        public IfmsContext(DbContextOptions<IfmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Detailhead> DetailHeads { get; set; } = null!;
        public virtual DbSet<SubDetailHead> SubDetailHeads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detailhead>(entity =>
            {
                entity.ToTable("detail_head", "master");

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

            modelBuilder.Entity<SubDetailHead>(entity =>
            {
                entity.ToTable("sub_detail_head", "master");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
