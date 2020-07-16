using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class editthaitable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thais_Englishes_EnglishId",
                table: "Thais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thais",
                table: "Thais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Englishes",
                table: "Englishes");

            migrationBuilder.RenameTable(
                name: "Thais",
                newName: "Thai");

            migrationBuilder.RenameTable(
                name: "Englishes",
                newName: "English");

            migrationBuilder.RenameIndex(
                name: "IX_Thais_EnglishId",
                table: "Thai",
                newName: "IX_Thai_EnglishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thai",
                table: "Thai",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_English",
                table: "English",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Thai_English_EnglishId",
                table: "Thai",
                column: "EnglishId",
                principalTable: "English",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thai_English_EnglishId",
                table: "Thai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thai",
                table: "Thai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_English",
                table: "English");

            migrationBuilder.RenameTable(
                name: "Thai",
                newName: "Thais");

            migrationBuilder.RenameTable(
                name: "English",
                newName: "Englishes");

            migrationBuilder.RenameIndex(
                name: "IX_Thai_EnglishId",
                table: "Thais",
                newName: "IX_Thais_EnglishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thais",
                table: "Thais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Englishes",
                table: "Englishes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Thais_Englishes_EnglishId",
                table: "Thais",
                column: "EnglishId",
                principalTable: "Englishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
