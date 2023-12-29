using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojaBiblioteka.Migrations
{
    public partial class BookCategoryModelFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Book_BooksIsbn",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categories_CategoriesCategoryId",
                table: "BookCategory");

            migrationBuilder.DropTable(
                name: "CategoryBook");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "BookCategory",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "BooksIsbn",
                table: "BookCategory",
                newName: "BookIsbn");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoriesCategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Book_BookIsbn",
                table: "BookCategory",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Categories_CategoryId",
                table: "BookCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Book_BookIsbn",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categories_CategoryId",
                table: "BookCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BookCategory",
                newName: "CategoriesCategoryId");

            migrationBuilder.RenameColumn(
                name: "BookIsbn",
                table: "BookCategory",
                newName: "BooksIsbn");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoriesCategoryId");

            migrationBuilder.CreateTable(
                name: "CategoryBook",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BookIsbn = table.Column<string>(type: "nvarchar(17)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBook", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryBook_Book_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Book",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBook_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBook_BookIsbn",
                table: "CategoryBook",
                column: "BookIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBook_CategoryId",
                table: "CategoryBook",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Book_BooksIsbn",
                table: "BookCategory",
                column: "BooksIsbn",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Categories_CategoriesCategoryId",
                table: "BookCategory",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
