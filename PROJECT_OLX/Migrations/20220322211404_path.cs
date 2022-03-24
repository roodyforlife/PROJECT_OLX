using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT_OLX.Migrations
{
    public partial class path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Adding",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Adding",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Adding");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Adding");
        }
    }
}
