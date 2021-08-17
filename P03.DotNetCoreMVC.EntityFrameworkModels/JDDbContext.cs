

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using P03.DotNetCoreMVC.Utility;
using P03.DotNetCoreMVC.EntityFrameworkModels.Models;
using P03.DotNetCoreMVC.EntityFrameworkModels.EFSqlLog;


namespace P03.DotNetCoreMVC.EntityFrameworkModels
{

    public partial class JDDbContext : DbContext
    {
        //core version is different with EF6
        //public JDDbContext()
        //    : base("name=JDDbContext")
        //{
        //    this.Database.Log += c => Console.WriteLine($"sql is: {c}");
        //    System.Data.Entity.Database.SetInitializer<JDDbContext>(null);
        //}

        //public JDDbContext()
        //{

        //}

        public JDDbContext(DbContextOptions options) : base(options)
        {


        }

        #region read connection string 3

        private IConfiguration _configuration = null;
        public JDDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        #endregion 



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //// read connection string 1
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=advanced7;User ID=adrian;Password=adrian");

            ////way of reading connection string 2 : read from json file, but file location maybe changed. 
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json");
            //var configuration = builder.Build();
            //var conn = configuration.GetConnectionString("JDDbConnectionString");
            //optionsBuilder.UseSqlServer(conn);


            ////read connection string 3, use configuration to get connection string. configuration is injected by container. 
            optionsBuilder.UseSqlServer(this._configuration.GetConnectionString("JDDbConnectionString"));


            //read connection string 4, try to avoid read configuration directly.
            //StaticConstraint is Init at project start up, so can read  here. 
            //optionsBuilder.UseSqlServer(StaticConstraint.connectionString);


            // 5 AddDbContext in Startup class


            #region Configure Logger for DBcontext

            optionsBuilder.UseLoggerFactory(new CustomEFLoggerFactory());

            #endregion


        }



        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<JD_Commodity_001> JD_Commodity_001 { get; set; }
        public virtual DbSet<JD_Commodity_002> JD_Commodity_002 { get; set; }
        public virtual DbSet<JD_Commodity_003> JD_Commodity_003 { get; set; }
        public virtual DbSet<JD_Commodity_004> JD_Commodity_004 { get; set; }
        public virtual DbSet<JD_Commodity_005> JD_Commodity_005 { get; set; }
        public virtual DbSet<JD_Commodity_006> JD_Commodity_006 { get; set; }
        public virtual DbSet<JD_Commodity_007> JD_Commodity_007 { get; set; }
        public virtual DbSet<JD_Commodity_008> JD_Commodity_008 { get; set; }
        public virtual DbSet<JD_Commodity_009> JD_Commodity_009 { get; set; }
        public virtual DbSet<JD_Commodity_010> JD_Commodity_010 { get; set; }
        public virtual DbSet<JD_Commodity_011> JD_Commodity_011 { get; set; }
        public virtual DbSet<JD_Commodity_012> JD_Commodity_012 { get; set; }
        public virtual DbSet<JD_Commodity_013> JD_Commodity_013 { get; set; }
        public virtual DbSet<JD_Commodity_014> JD_Commodity_014 { get; set; }
        public virtual DbSet<JD_Commodity_015> JD_Commodity_015 { get; set; }
        public virtual DbSet<JD_Commodity_016> JD_Commodity_016 { get; set; }
        public virtual DbSet<JD_Commodity_017> JD_Commodity_017 { get; set; }
        public virtual DbSet<JD_Commodity_018> JD_Commodity_018 { get; set; }
        public virtual DbSet<JD_Commodity_019> JD_Commodity_019 { get; set; }
        public virtual DbSet<JD_Commodity_020> JD_Commodity_020 { get; set; }
        public virtual DbSet<JD_Commodity_021> JD_Commodity_021 { get; set; }
        public virtual DbSet<JD_Commodity_022> JD_Commodity_022 { get; set; }
        public virtual DbSet<JD_Commodity_023> JD_Commodity_023 { get; set; }
        public virtual DbSet<JD_Commodity_024> JD_Commodity_024 { get; set; }
        public virtual DbSet<JD_Commodity_025> JD_Commodity_025 { get; set; }
        public virtual DbSet<JD_Commodity_026> JD_Commodity_026 { get; set; }
        public virtual DbSet<JD_Commodity_027> JD_Commodity_027 { get; set; }
        public virtual DbSet<JD_Commodity_028> JD_Commodity_028 { get; set; }
        public virtual DbSet<JD_Commodity_029> JD_Commodity_029 { get; set; }
        public virtual DbSet<JD_Commodity_030> JD_Commodity_030 { get; set; }
        public virtual DbSet<SysLog> SysLogs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMenuMapping> UserMenuMappings { get; set; }
        public virtual DbSet<SysMenu> SysMenus { get; set; }
        public virtual DbSet<SysRole> SysRoles { get; set; }
        public virtual DbSet<SysRoleMenuMapping> SysRoleMenuMappings { get; set; }


        //difference with EF6 Version.
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ParentCode)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_001>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_001>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_002>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_002>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_003>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_003>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_004>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_004>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_005>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_005>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_006>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_006>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_007>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_007>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_008>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_008>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_009>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_009>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_010>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_010>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_011>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_011>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_012>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_012>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_013>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_013>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_014>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_014>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_015>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_015>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_016>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_016>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_017>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_017>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_018>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_018>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_019>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_019>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_020>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_020>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_021>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_021>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_022>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_022>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_023>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_023>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_024>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_024>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_025>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_025>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_026>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_026>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_027>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_027>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_028>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_028>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_029>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_029>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_030>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<JD_Commodity_030>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<SysMenu>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<SysMenu>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SysMenu>()
                .Property(e => e.SourcePath)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.SourcePath)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);
        }
    }
}
