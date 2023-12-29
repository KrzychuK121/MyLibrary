using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojaBiblioteka.Migrations
{
    public partial class NameLastNameContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Name_NameId",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Name",
                table: "Name");

            migrationBuilder.RenameTable(
                name: "Name",
                newName: "Names");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Names",
                table: "Names",
                column: "NameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Names_NameId",
                table: "Author",
                column: "NameId",
                principalTable: "Names",
                principalColumn: "NameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Names_NameId",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Names",
                table: "Names");

            migrationBuilder.RenameTable(
                name: "Names",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Name",
                table: "Name",
                column: "NameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Name_NameId",
                table: "Author",
                column: "NameId",
                principalTable: "Name",
                principalColumn: "NameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
