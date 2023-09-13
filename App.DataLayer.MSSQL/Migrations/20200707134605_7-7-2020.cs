using Microsoft.EntityFrameworkCore.Migrations;

namespace App.DataLayer.MSSQL.Migrations
{
    public partial class _772020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Direction",
                table: "LocationLogs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "Odometer",
                table: "LocationLogs",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "LocationLogs");

            migrationBuilder.DropColumn(
                name: "Odometer",
                table: "LocationLogs");
        }
    }
}
