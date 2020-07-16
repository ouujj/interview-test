using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ChangChartmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "change_ad",
                table: "charts");

            migrationBuilder.DropColumn(
                name: "change_sap",
                table: "charts");

            migrationBuilder.DropColumn(
                name: "reset_ad",
                table: "charts");

            migrationBuilder.DropColumn(
                name: "reset_sap",
                table: "charts");

            migrationBuilder.DropColumn(
                name: "unlock_ad",
                table: "charts");

            migrationBuilder.DropColumn(
                name: "unlock_sap",
                table: "charts");

            migrationBuilder.AddColumn<string>(
                name: "intent",
                table: "charts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "point",
                table: "charts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "subintent",
                table: "charts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "intent",
                table: "charts");

            migrationBuilder.DropColumn(
                name: "point",
                table: "charts");

            migrationBuilder.DropColumn(
                name: "subintent",
                table: "charts");

            migrationBuilder.AddColumn<int>(
                name: "change_ad",
                table: "charts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "change_sap",
                table: "charts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reset_ad",
                table: "charts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reset_sap",
                table: "charts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unlock_ad",
                table: "charts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unlock_sap",
                table: "charts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
