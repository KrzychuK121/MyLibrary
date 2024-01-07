using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojaBiblioteka.Migrations
{
    public partial class RentalTransactionAttributeFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ifReturned",
                table: "RentalTransactionList");

            migrationBuilder.AddColumn<int>(
                name: "ProlongTermCounter",
                table: "RentalTransactionList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RentalTransactionList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProlongTermCounter",
                table: "RentalTransactionList");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RentalTransactionList");

            migrationBuilder.AddColumn<bool>(
                name: "ifReturned",
                table: "RentalTransactionList",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
