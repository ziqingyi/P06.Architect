using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst2.ModelsFromDB;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst2
{
    public partial class EFCoreContextContext : DbContext
    {
        public string conn = "Server=.;Database=EFCoreContext;uid=adrian;pwd=adrian;";
        public EFCoreContextContext()
        {
        }

        public EFCoreContextContext(DbContextOptions<EFCoreContextContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conmpany> Conmpany { get; set; }
        public virtual DbSet<SysLogInfo> SysLogInfo { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserInfoDetail> SysUserInfoDetail { get; set; }
        public virtual DbSet<SysUserRoleMapping> SysUserRoleMapping { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysLogInfo>(entity =>
            {
                entity.Property(e => e.UserName).HasMaxLength(36);
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.MenuIcon).HasMaxLength(20);

                entity.Property(e => e.SourcePath).HasMaxLength(1000);

                entity.Property(e => e.SysMenuName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Url).HasMaxLength(500);
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.CompanyId1);

                entity.HasIndex(e => new { e.Name, e.Phone });

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Qq).HasColumnName("QQ");

                entity.Property(e => e.WeChat).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.SysUserCompany)
                    .HasForeignKey(d => d.CompanyId);

                entity.HasOne(d => d.CompanyId1Navigation)
                    .WithMany(p => p.SysUserCompanyId1Navigation)
                    .HasForeignKey(d => d.CompanyId1);
            });

            modelBuilder.Entity<SysUserInfoDetail>(entity =>
            {
                entity.HasIndex(e => e.SysUserInfoDetailId)
                    .IsUnique();

                entity.HasIndex(e => e.SysUserInfoId);
            });

            modelBuilder.Entity<SysUserRoleMapping>(entity =>
            {
                entity.HasKey(e => new { e.SysUserId, e.SysRoleId });

                entity.HasIndex(e => e.SysRoleId);

                entity.HasOne(d => d.SysRole)
                    .WithMany(p => p.SysUserRoleMapping)
                    .HasForeignKey(d => d.SysRoleId);

                entity.HasOne(d => d.SysUser)
                    .WithMany(p => p.SysUserRoleMapping)
                    .HasForeignKey(d => d.SysUserId);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.SysUserId);

                entity.HasOne(d => d.SysUser)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.SysUserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
