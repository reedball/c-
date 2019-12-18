using Microsoft.EntityFrameworkCore.Migrations;

namespace CBelt.Migrations
{
    public partial class LatLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "Activs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Long",
                table: "Activs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Activs");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Activs");
        }
    }
}
