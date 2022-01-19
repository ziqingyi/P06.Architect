using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB
{
    public partial class advanced7ContextNew : DbContext
    {
        #region add new log factory

        /*
           1  Microsoft.Extensions.Logging   +   Microsoft.Extensions.Logging.Console 
           2  myLoggerFactory  
           3  optionsBuilder.UseLoggerFactory(myLoggerFactory)
        */
        public static readonly ILoggerFactory myLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        #endregion


        public advanced7ContextNew()
        {
        }

        public advanced7ContextNew(DbContextOptions<advanced7ContextNew> options)
            : base(options)
        {
        }

        public virtual DbSet<AggregatedCounter> AggregatedCounter { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<JdCommodity001> JdCommodity001 { get; set; }
        public virtual DbSet<JdCommodity002> JdCommodity002 { get; set; }
        public virtual DbSet<JdCommodity003> JdCommodity003 { get; set; }
        public virtual DbSet<JdCommodity004> JdCommodity004 { get; set; }
        public virtual DbSet<JdCommodity005> JdCommodity005 { get; set; }
        public virtual DbSet<JdCommodity006> JdCommodity006 { get; set; }
        public virtual DbSet<JdCommodity007> JdCommodity007 { get; set; }
        public virtual DbSet<JdCommodity008> JdCommodity008 { get; set; }
        public virtual DbSet<JdCommodity009> JdCommodity009 { get; set; }
        public virtual DbSet<JdCommodity010> JdCommodity010 { get; set; }
        public virtual DbSet<JdCommodity011> JdCommodity011 { get; set; }
        public virtual DbSet<JdCommodity012> JdCommodity012 { get; set; }
        public virtual DbSet<JdCommodity013> JdCommodity013 { get; set; }
        public virtual DbSet<JdCommodity014> JdCommodity014 { get; set; }
        public virtual DbSet<JdCommodity015> JdCommodity015 { get; set; }
        public virtual DbSet<JdCommodity016> JdCommodity016 { get; set; }
        public virtual DbSet<JdCommodity017> JdCommodity017 { get; set; }
        public virtual DbSet<JdCommodity018> JdCommodity018 { get; set; }
        public virtual DbSet<JdCommodity019> JdCommodity019 { get; set; }
        public virtual DbSet<JdCommodity020> JdCommodity020 { get; set; }
        public virtual DbSet<JdCommodity021> JdCommodity021 { get; set; }
        public virtual DbSet<JdCommodity022> JdCommodity022 { get; set; }
        public virtual DbSet<JdCommodity023> JdCommodity023 { get; set; }
        public virtual DbSet<JdCommodity024> JdCommodity024 { get; set; }
        public virtual DbSet<JdCommodity025> JdCommodity025 { get; set; }
        public virtual DbSet<JdCommodity026> JdCommodity026 { get; set; }
        public virtual DbSet<JdCommodity027> JdCommodity027 { get; set; }
        public virtual DbSet<JdCommodity028> JdCommodity028 { get; set; }
        public virtual DbSet<JdCommodity029> JdCommodity029 { get; set; }
        public virtual DbSet<JdCommodity030> JdCommodity030 { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<JobQueue> JobQueue { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleMenuMapping> SysRoleMenuMapping { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserMenuMapping> SysUserMenuMapping { get; set; }
        public virtual DbSet<SysUserRoleMapping> SysUserRoleMapping { get; set; }
        public virtual DbSet<TestTable> TestTable { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserMenuMapping> UserMenuMapping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseLoggerFactory(myLoggerFactory)
                    .UseSqlServer("Server=.;Database=advanced7_new;uid=adrian;pwd=adrian");
                //optionsBuilder.UseSqlServer("Server=.;Database=advanced7_new;uid=adrian;pwd=adrian");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_AggregatedCounter_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ParentCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_User");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "HangFire");

                entity.HasIndex(e => e.Key)
                    .HasName("CX_HangFire_Counter")
                    .IsClustered();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Hash_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<JdCommodity001>(entity =>
            {
                entity.ToTable("JD_Commodity_001");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity002>(entity =>
            {
                entity.ToTable("JD_Commodity_002");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity003>(entity =>
            {
                entity.ToTable("JD_Commodity_003");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity004>(entity =>
            {
                entity.ToTable("JD_Commodity_004");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity005>(entity =>
            {
                entity.ToTable("JD_Commodity_005");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity006>(entity =>
            {
                entity.ToTable("JD_Commodity_006");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity007>(entity =>
            {
                entity.ToTable("JD_Commodity_007");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity008>(entity =>
            {
                entity.ToTable("JD_Commodity_008");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity009>(entity =>
            {
                entity.ToTable("JD_Commodity_009");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity010>(entity =>
            {
                entity.ToTable("JD_Commodity_010");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity011>(entity =>
            {
                entity.ToTable("JD_Commodity_011");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity012>(entity =>
            {
                entity.ToTable("JD_Commodity_012");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity013>(entity =>
            {
                entity.ToTable("JD_Commodity_013");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity014>(entity =>
            {
                entity.ToTable("JD_Commodity_014");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity015>(entity =>
            {
                entity.ToTable("JD_Commodity_015");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity016>(entity =>
            {
                entity.ToTable("JD_Commodity_016");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity017>(entity =>
            {
                entity.ToTable("JD_Commodity_017");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity018>(entity =>
            {
                entity.ToTable("JD_Commodity_018");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity019>(entity =>
            {
                entity.ToTable("JD_Commodity_019");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity020>(entity =>
            {
                entity.ToTable("JD_Commodity_020");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity021>(entity =>
            {
                entity.ToTable("JD_Commodity_021");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity022>(entity =>
            {
                entity.ToTable("JD_Commodity_022");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity023>(entity =>
            {
                entity.ToTable("JD_Commodity_023");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity024>(entity =>
            {
                entity.ToTable("JD_Commodity_024");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity025>(entity =>
            {
                entity.ToTable("JD_Commodity_025");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity026>(entity =>
            {
                entity.ToTable("JD_Commodity_026");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity027>(entity =>
            {
                entity.ToTable("JD_Commodity_027");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity028>(entity =>
            {
                entity.ToTable("JD_Commodity_028");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity029>(entity =>
            {
                entity.ToTable("JD_Commodity_029");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JdCommodity030>(entity =>
            {
                entity.ToTable("JD_Commodity_030");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangFire");

                entity.HasIndex(e => e.StateName)
                    .HasName("IX_HangFire_Job_StateName")
                    .HasFilter("([StateName] IS NOT NULL)");

                entity.HasIndex(e => new { e.StateName, e.ExpireAt })
                    .HasName("IX_HangFire_Job_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangFire");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangFire");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_List_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.LastModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SourcePath)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasComment("父级path/datetime+random");

                entity.Property(e => e.State).HasComment("菜单状态  0正常 1冻结 2删除");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangFire");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangFire");

                entity.HasIndex(e => e.LastHeartbeat)
                    .HasName("IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Set_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => new { e.Key, e.Score })
                    .HasName("IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangFire");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<SysLog>(entity =>
            {
                entity.HasComment("系统日志表");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.CreatorId).HasComment("操作用户");

                entity.Property(e => e.Detail)
                    .HasMaxLength(4000)
                    .HasComment("详细信息");

                entity.Property(e => e.Introduction)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasComment("简介");

                entity.Property(e => e.LastModifierId).HasComment("修改用户");

                entity.Property(e => e.LastModifyTime)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.LogType)
                    .HasDefaultValueSql("((1))")
                    .HasComment(@"操作类型：0信息操作，1 登陆退出
   2 增
   3 删
   4 改
   5 启用禁用
   6 申请/审核通过/拒绝
   7 导入导出
   8 上传下载
   100 其他");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasComment("操作者名称，没有就写系统生成");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.HasComment("管理后台菜单表");

                entity.Property(e => e.Id).HasComment("编号");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.CreatorId).HasComment("添加用户");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("说明");

                entity.Property(e => e.LastModifierId).HasComment("修改用户");

                entity.Property(e => e.LastModifyTime)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(20)
                    .HasComment("菜单图标");

                entity.Property(e => e.MenuLevel)
                    .HasDefaultValueSql("((1))")
                    .HasComment("菜单等级");

                entity.Property(e => e.MenuType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("类型：1 菜单 2 按钮");

                entity.Property(e => e.ParentId).HasComment("上级菜单：根目录id为0");

                entity.Property(e => e.Sort).HasComment("排序值");

                entity.Property(e => e.SourcePath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasComment(@"菜单路径：parentpath/guid
   一级菜单为 root/guid");

                entity.Property(e => e.Status).HasComment("状态：0  正常  1 冻结  2 删除");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("菜单名称");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("链接地址");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasComment("管理后台用户角色表");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.LastModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Status).HasComment("状态：0  正常  1 冻结  2 删除");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<SysRoleMenuMapping>(entity =>
            {
                entity.HasComment("角色和菜单映射表，一个角色对应多菜单   一个菜单多个角色");

                entity.Property(e => e.Id).HasComment("编号");

                entity.Property(e => e.SysMenuId).HasComment("菜单Id");

                entity.Property(e => e.SysRoleId).HasComment("角色Id");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasComment("后台管理员表");

                entity.Property(e => e.Id).HasComment("编号");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasComment("联系地址");

                entity.Property(e => e.CreateId).HasComment("添加用户");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("联系邮箱");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("datetime")
                    .HasComment("最后登陆时间");

                entity.Property(e => e.LastModifyId).HasComment("修改用户");

                entity.Property(e => e.LastModifyTime)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("手机号");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("用户名");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasComment("密码");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("联系电话");

                entity.Property(e => e.Qq)
                    .HasColumnName("QQ")
                    .HasComment("联系QQ");

                entity.Property(e => e.Sex).HasComment("性别  0男 1女");

                entity.Property(e => e.Status).HasComment("用户状态");

                entity.Property(e => e.WeChat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("微信号");
            });

            modelBuilder.Entity<SysUserMenuMapping>(entity =>
            {
                entity.HasComment(@"用户和菜单映射表,额外补充用户权限
   一个用户对应多菜单   一个菜单多个角色");
            });

            modelBuilder.Entity<SysUserRoleMapping>(entity =>
            {
                entity.HasComment("用户和角色映射表，一个用户可能多个角色，一个角色多个用户");

                entity.Property(e => e.Id).HasComment("编号");

                entity.Property(e => e.SysRoleId).HasComment("角色Id");

                entity.Property(e => e.SysUserId).HasComment("用户Id");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName).HasMaxLength(500);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasComment("用户状态  0正常 1冻结 2删除");

                entity.Property(e => e.UserType).HasComment("用户类型  1 普通用户 2管理员 4超级管理员");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_User_Company");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
