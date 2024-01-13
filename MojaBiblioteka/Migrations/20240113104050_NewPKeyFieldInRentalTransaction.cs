using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojaBiblioteka.Migrations
{
    public partial class NewPKeyFieldInRentalTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalTransactionList",
                table: "RentalTransactionList");

            migrationBuilder.AddColumn<int>(
                name: "RentalTransactionId",
                table: "RentalTransactionList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalTransactionList",
                table: "RentalTransactionList",
                column: "RentalTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalTransactionList_BookIsbn",
                table: "RentalTransactionList",
                column: "BookIsbn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalTransactionList",
                table: "RentalTransactionList");

            migrationBuilder.DropIndex(
                name: "IX_RentalTransactionList_BookIsbn",
                table: "RentalTransactionList");

            migrationBuilder.DropColumn(
                name: "RentalTransactionId",
                table: "RentalTransactionList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalTransactionList",
                table: "RentalTransactionList",
                columns: new[] { "BookIsbn", "UserId" });
        }
    }
}
