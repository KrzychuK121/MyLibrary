using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojaBiblioteka.Migrations
{
    public partial class RentalTransactionAttributeExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "RentalTransactionList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalDate",
                table: "RentalTransactionList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "ifReturned",
                table: "RentalTransactionList",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "RentalTransactionList");

            migrationBuilder.DropColumn(
                name: "RentalDate",
                table: "RentalTransactionList");

            migrationBuilder.DropColumn(
                name: "ifReturned",
                table: "RentalTransactionList");
        }
    }
}
