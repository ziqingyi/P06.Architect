using Microsoft.EntityFrameworkCore.Migrations;

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.Migrations
{
    public partial class Init03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name2",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name2",
                table: "Company");
        }
    }
}
