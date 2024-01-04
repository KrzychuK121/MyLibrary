using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojaBiblioteka.Migrations
{
    public partial class AuthorsPropertyRenameContextTablesRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_LastName_SurnameLastNameId",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Author_Names_NameId",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publishers_PublisherId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Book_BookIsbn",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Book_BookIsbn",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categories_CategoryId",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LastName",
                table: "LastName");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BookCate__D1DA9B4023BFAE22",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "LastName",
                newName: "LastNames");

            migrationBuilder.RenameTable(
                name: "BookCategory",
                newName: "BooksCategories");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "BooksAuthors");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameColumn(
                name: "Fistname",
                table: "Names",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BooksCategories",
                newName: "IX_BooksCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BooksAuthors",
                newName: "IX_BooksAuthors_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_PublisherId",
                table: "Books",
                newName: "IX_Books_PublisherId");

            migrationBuilder.RenameColumn(
                name: "NameId",
                table: "Authors",
                newName: "FirstNameNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Author_SurnameLastNameId",
                table: "Authors",
                newName: "IX_Authors_SurnameLastNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Author_NameId",
                table: "Authors",
                newName: "IX_Authors_FirstNameNameId");

            migrationBuilder.AddColumn<int>(
                name: "FirstNameNameId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurnameLastNameId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastNames",
                table: "LastNames",
                column: "LastNameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksCategories",
                table: "BooksCategories",
                columns: new[] { "BookIsbn", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors",
                columns: new[] { "BookIsbn", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Isbn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FirstNameNameId",
                table: "AspNetUsers",
                column: "FirstNameNameId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SurnameLastNameId",
                table: "AspNetUsers",
                column: "SurnameLastNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LastNames_SurnameLastNameId",
                table: "AspNetUsers",
                column: "SurnameLastNameId",
                principalTable: "LastNames",
                principalColumn: "LastNameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Names_FirstNameNameId",
                table: "AspNetUsers",
                column: "FirstNameNameId",
                principalTable: "Names",
                principalColumn: "NameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_LastNames_SurnameLastNameId",
                table: "Authors",
                column: "SurnameLastNameId",
                principalTable: "LastNames",
                principalColumn: "LastNameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Names_FirstNameNameId",
                table: "Authors",
                column: "FirstNameNameId",
                principalTable: "Names",
                principalColumn: "NameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAuthors_Authors_AuthorId",
                table: "BooksAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAuthors_Books_BookIsbn",
                table: "BooksAuthors",
                column: "BookIsbn",
                principalTable: "Books",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCategories_Books_BookIsbn",
                table: "BooksCategories",
                column: "BookIsbn",
                principalTable: "Books",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCategories_Categories_CategoryId",
                table: "BooksCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LastNames_SurnameLastNameId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Names_FirstNameNameId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Authors_LastNames_SurnameLastNameId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Names_FirstNameNameId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAuthors_Authors_AuthorId",
                table: "BooksAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAuthors_Books_BookIsbn",
                table: "BooksAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksCategories_Books_BookIsbn",
                table: "BooksCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksCategories_Categories_CategoryId",
                table: "BooksCategories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FirstNameNameId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SurnameLastNameId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LastNames",
                table: "LastNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksCategories",
                table: "BooksCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "FirstNameNameId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurnameLastNameId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "LastNames",
                newName: "LastName");

            migrationBuilder.RenameTable(
                name: "BooksCategories",
                newName: "BookCategory");

            migrationBuilder.RenameTable(
                name: "BooksAuthors",
                newName: "BookAuthor");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Names",
                newName: "Fistname");

            migrationBuilder.RenameIndex(
                name: "IX_BooksCategories_CategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksAuthors_AuthorId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PublisherId",
                table: "Book",
                newName: "IX_Book_PublisherId");

            migrationBuilder.RenameColumn(
                name: "FirstNameNameId",
                table: "Author",
                newName: "NameId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_SurnameLastNameId",
                table: "Author",
                newName: "IX_Author_SurnameLastNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_FirstNameNameId",
                table: "Author",
                newName: "IX_Author_NameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastName",
                table: "LastName",
                column: "LastNameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                columns: new[] { "BookIsbn", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                columns: new[] { "BookIsbn", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Isbn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_LastName_SurnameLastNameId",
                table: "Author",
                column: "SurnameLastNameId",
                principalTable: "LastName",
                principalColumn: "LastNameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Names_NameId",
                table: "Author",
                column: "NameId",
                principalTable: "Names",
                principalColumn: "NameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publishers_PublisherId",
                table: "Book",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Book_BookIsbn",
                table: "BookAuthor",
                column: "BookIsbn",
                principalTable: "Book",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Cascade);

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
    }
}
