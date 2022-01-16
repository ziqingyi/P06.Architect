using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.Migrations
{
    public partial class Init01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HangFire");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ParentCode = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CategoryLevel = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    State = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_001",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_001", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_002",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_002", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_003",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_003", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_004",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_004", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_005",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_005", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_006",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_006", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_007",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_007", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_008",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_008", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_009",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_009", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_010",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_010", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_011",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_011", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_012",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_012", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_013",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_013", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_014",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_014", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_015",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_015", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_016",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_016", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_017",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_017", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_018",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_018", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_019",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_019", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_020",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_020", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_021",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_021", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_022",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_022", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_023",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_023", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_024",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_024", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_025",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_025", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_026",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_026", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_027",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_027", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_028",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_028", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_029",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_029", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_030",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_030", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SourcePath = table.Column<string>(unicode: false, maxLength: 1000, nullable: false, comment: "父级path/datetime+random"),
                    State = table.Column<int>(nullable: false, comment: "菜单状态  0正常 1冻结 2删除"),
                    MenuLevel = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    LastModifierId = table.Column<int>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 36, nullable: false, comment: "操作者名称，没有就写系统生成"),
                    Introduction = table.Column<string>(maxLength: 1000, nullable: false, comment: "简介"),
                    Detail = table.Column<string>(maxLength: 4000, nullable: true, comment: "详细信息"),
                    LogType = table.Column<byte>(nullable: false, defaultValueSql: "((1))", comment: @"操作类型：0信息操作，1 登陆退出
   2 增
   3 删
   4 改
   5 启用禁用
   6 申请/审核通过/拒绝
   7 导入导出
   8 上传下载
   100 其他"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "添加时间"),
                    CreatorId = table.Column<int>(nullable: false, comment: "操作用户"),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间"),
                    LastModifierId = table.Column<int>(nullable: true, comment: "修改用户")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysLog", x => x.Id);
                },
                comment: "系统日志表");

            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, comment: "编号")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: false, comment: "上级菜单：根目录id为0"),
                    Text = table.Column<string>(maxLength: 100, nullable: false, comment: "菜单名称"),
                    Url = table.Column<string>(unicode: false, maxLength: 500, nullable: true, comment: "链接地址"),
                    MenuLevel = table.Column<byte>(nullable: false, defaultValueSql: "((1))", comment: "菜单等级"),
                    MenuType = table.Column<byte>(nullable: false, defaultValueSql: "((1))", comment: "类型：1 菜单 2 按钮"),
                    MenuIcon = table.Column<string>(maxLength: 20, nullable: true, comment: "菜单图标"),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true, comment: "说明"),
                    SourcePath = table.Column<string>(unicode: false, maxLength: 1000, nullable: true, comment: @"菜单路径：parentpath/guid
   一级菜单为 root/guid"),
                    Sort = table.Column<int>(nullable: false, comment: "排序值"),
                    Status = table.Column<byte>(nullable: false, comment: "状态：0  正常  1 冻结  2 删除"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "添加时间"),
                    CreatorId = table.Column<int>(nullable: false, comment: "添加用户"),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间"),
                    LastModifierId = table.Column<int>(nullable: true, comment: "修改用户")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                },
                comment: "管理后台菜单表");

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 36, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<byte>(nullable: false, comment: "状态：0  正常  1 冻结  2 删除"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateId = table.Column<int>(nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                },
                comment: "管理后台用户角色表");

            migrationBuilder.CreateTable(
                name: "SysRoleMenuMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, comment: "编号")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysRoleId = table.Column<int>(nullable: false, comment: "角色Id"),
                    SysMenuId = table.Column<int>(nullable: false, comment: "菜单Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleMenuMapping", x => x.Id);
                },
                comment: "角色和菜单映射表，一个角色对应多菜单   一个菜单多个角色");

            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, comment: "编号")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false, comment: "用户名"),
                    Password = table.Column<string>(maxLength: 64, nullable: false, comment: "密码"),
                    Status = table.Column<byte>(nullable: false, comment: "用户状态"),
                    Phone = table.Column<string>(unicode: false, maxLength: 20, nullable: true, comment: "联系电话"),
                    Mobile = table.Column<string>(unicode: false, maxLength: 20, nullable: true, comment: "手机号"),
                    Address = table.Column<string>(maxLength: 50, nullable: true, comment: "联系地址"),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true, comment: "联系邮箱"),
                    QQ = table.Column<long>(nullable: true, comment: "联系QQ"),
                    WeChat = table.Column<string>(unicode: false, maxLength: 50, nullable: true, comment: "微信号"),
                    Sex = table.Column<byte>(nullable: true, comment: "性别  0男 1女"),
                    LastLoginTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后登陆时间"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "添加时间"),
                    CreateId = table.Column<int>(nullable: false, comment: "添加用户"),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间"),
                    LastModifyId = table.Column<int>(nullable: true, comment: "修改用户")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.Id);
                },
                comment: "后台管理员表");

            migrationBuilder.CreateTable(
                name: "SysUserMenuMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysUserId = table.Column<int>(nullable: false),
                    SysMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserMenuMapping", x => x.Id);
                },
                comment: @"用户和菜单映射表,额外补充用户权限
   一个用户对应多菜单   一个菜单多个角色");

            migrationBuilder.CreateTable(
                name: "SysUserRoleMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, comment: "编号")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysUserId = table.Column<int>(nullable: false, comment: "用户Id"),
                    SysRoleId = table.Column<int>(nullable: false, comment: "角色Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserRoleMapping", x => x.Id);
                },
                comment: "用户和角色映射表，一个用户可能多个角色，一个角色多个用户");

            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMenuMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMenuMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AggregatedCounter",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<long>(nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_CounterAggregated", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Counter",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<int>(nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Hash",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    Field = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ExpireAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Hash", x => new { x.Key, x.Field });
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "HangFire",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<long>(nullable: true),
                    StateName = table.Column<string>(maxLength: 20, nullable: true),
                    InvocationData = table.Column<string>(nullable: false),
                    Arguments = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobQueue",
                schema: "HangFire",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Queue = table.Column<string>(maxLength: 50, nullable: false),
                    JobId = table.Column<long>(nullable: false),
                    FetchedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_JobQueue", x => new { x.Queue, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "List",
                schema: "HangFire",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_List", x => new { x.Key, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Schema",
                schema: "HangFire",
                columns: table => new
                {
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Schema", x => x.Version);
                });

            migrationBuilder.CreateTable(
                name: "Server",
                schema: "HangFire",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 200, nullable: false),
                    Data = table.Column<string>(nullable: true),
                    LastHeartbeat = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Set",
                schema: "HangFire",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<string>(maxLength: 256, nullable: false),
                    Score = table.Column<double>(nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_Set", x => new { x.Key, x.Value });
                });

            migrationBuilder.CreateTable(
                name: "JobParameter",
                schema: "HangFire",
                columns: table => new
                {
                    JobId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_JobParameter", x => new { x.JobId, x.Name });
                    table.ForeignKey(
                        name: "FK_HangFire_JobParameter_Job",
                        column: x => x.JobId,
                        principalSchema: "HangFire",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "HangFire",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Reason = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangFire_State", x => new { x.JobId, x.Id });
                    table.ForeignKey(
                        name: "FK_HangFire_State_Job",
                        column: x => x.JobId,
                        principalSchema: "HangFire",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Account = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Mobile = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    CompanyName = table.Column<string>(maxLength: 500, nullable: true),
                    State = table.Column<int>(nullable: false, comment: "用户状态  0正常 1冻结 2删除"),
                    UserType = table.Column<int>(nullable: false, comment: "用户类型  1 普通用户 2管理员 4超级管理员"),
                    LastLoginTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    LastModifierId = table.Column<int>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    LastModifierId = table.Column<int>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_User",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CreatorId",
                table: "Company",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_AggregatedCounter_ExpireAt",
                schema: "HangFire",
                table: "AggregatedCounter",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "CX_HangFire_Counter",
                schema: "HangFire",
                table: "Counter",
                column: "Key")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Hash_ExpireAt",
                schema: "HangFire",
                table: "Hash",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Job_StateName",
                schema: "HangFire",
                table: "Job",
                column: "StateName",
                filter: "([StateName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Job_ExpireAt",
                schema: "HangFire",
                table: "Job",
                columns: new[] { "StateName", "ExpireAt" },
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_List_ExpireAt",
                schema: "HangFire",
                table: "List",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Server_LastHeartbeat",
                schema: "HangFire",
                table: "Server",
                column: "LastHeartbeat");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Set_ExpireAt",
                schema: "HangFire",
                table: "Set",
                column: "ExpireAt",
                filter: "([ExpireAt] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_HangFire_Set_Score",
                schema: "HangFire",
                table: "Set",
                columns: new[] { "Key", "Score" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Company",
                table: "User",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_User",
                table: "Company");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "JD_Commodity_001");

            migrationBuilder.DropTable(
                name: "JD_Commodity_002");

            migrationBuilder.DropTable(
                name: "JD_Commodity_003");

            migrationBuilder.DropTable(
                name: "JD_Commodity_004");

            migrationBuilder.DropTable(
                name: "JD_Commodity_005");

            migrationBuilder.DropTable(
                name: "JD_Commodity_006");

            migrationBuilder.DropTable(
                name: "JD_Commodity_007");

            migrationBuilder.DropTable(
                name: "JD_Commodity_008");

            migrationBuilder.DropTable(
                name: "JD_Commodity_009");

            migrationBuilder.DropTable(
                name: "JD_Commodity_010");

            migrationBuilder.DropTable(
                name: "JD_Commodity_011");

            migrationBuilder.DropTable(
                name: "JD_Commodity_012");

            migrationBuilder.DropTable(
                name: "JD_Commodity_013");

            migrationBuilder.DropTable(
                name: "JD_Commodity_014");

            migrationBuilder.DropTable(
                name: "JD_Commodity_015");

            migrationBuilder.DropTable(
                name: "JD_Commodity_016");

            migrationBuilder.DropTable(
                name: "JD_Commodity_017");

            migrationBuilder.DropTable(
                name: "JD_Commodity_018");

            migrationBuilder.DropTable(
                name: "JD_Commodity_019");

            migrationBuilder.DropTable(
                name: "JD_Commodity_020");

            migrationBuilder.DropTable(
                name: "JD_Commodity_021");

            migrationBuilder.DropTable(
                name: "JD_Commodity_022");

            migrationBuilder.DropTable(
                name: "JD_Commodity_023");

            migrationBuilder.DropTable(
                name: "JD_Commodity_024");

            migrationBuilder.DropTable(
                name: "JD_Commodity_025");

            migrationBuilder.DropTable(
                name: "JD_Commodity_026");

            migrationBuilder.DropTable(
                name: "JD_Commodity_027");

            migrationBuilder.DropTable(
                name: "JD_Commodity_028");

            migrationBuilder.DropTable(
                name: "JD_Commodity_029");

            migrationBuilder.DropTable(
                name: "JD_Commodity_030");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "SysLog");

            migrationBuilder.DropTable(
                name: "SysMenu");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "SysRoleMenuMapping");

            migrationBuilder.DropTable(
                name: "SysUser");

            migrationBuilder.DropTable(
                name: "SysUserMenuMapping");

            migrationBuilder.DropTable(
                name: "SysUserRoleMapping");

            migrationBuilder.DropTable(
                name: "TestTable");

            migrationBuilder.DropTable(
                name: "UserMenuMapping");

            migrationBuilder.DropTable(
                name: "AggregatedCounter",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Counter",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Hash",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "JobParameter",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "JobQueue",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "List",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Schema",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Server",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Set",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "State",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "HangFire");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
