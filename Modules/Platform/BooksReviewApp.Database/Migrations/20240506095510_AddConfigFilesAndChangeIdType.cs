using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BooksReviewApp.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigFilesAndChangeIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var booksAuthorsConstraint = migrationBuilder.Sql(
                "SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA = 'public' AND TABLE_NAME = 'Books' AND CONSTRAINT_NAME = 'FK_Books_Authors_AuthorId'",
                suppressTransaction: true).ToString() == "1";

            if (booksAuthorsConstraint)
            {
                migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");
            }

            var favoritesBooksConstraint = migrationBuilder.Sql(
                "SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA = 'public' AND TABLE_NAME = 'Favorites' AND CONSTRAINT_NAME = 'FK_Favorites_Books_BookId'",
                suppressTransaction: true).ToString() == "1";

            if (favoritesBooksConstraint)
            {
                migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Books_BookId",
                table: "Favorites");
            }

            var favoritesUsersConstraint = migrationBuilder.Sql(
                "SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA = 'public' AND TABLE_NAME = 'Favorites' AND CONSTRAINT_NAME = 'FK_Favorites_Users_UserId'",
                suppressTransaction: true).ToString() == "1";

            if (favoritesUsersConstraint)
            {
                migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");
            }

            var reviewsBooksConstraint = migrationBuilder.Sql(
                "SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA = 'public' AND TABLE_NAME = 'Reviews' AND CONSTRAINT_NAME = 'FK_Reviews_Books_BookId'",
                suppressTransaction: true).ToString() == "1";

            if (reviewsBooksConstraint)
            {
                migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews");
            }

            var reviewsUsersConstraint = migrationBuilder.Sql(
                "SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA = 'public' AND TABLE_NAME = 'Reviews' AND CONSTRAINT_NAME = 'FK_Reviews_Users_UserId'",
                suppressTransaction: true).ToString() == "1";

            if (reviewsUsersConstraint)
            {
                migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");
            }

            var bookGenreTableExists = migrationBuilder.Sql(
                "SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'public' AND TABLE_NAME = 'BookGenre'",
                suppressTransaction: true).ToString() == "1";

            if (bookGenreTableExists)
            {
                migrationBuilder.DropTable(
                name: "BookGenre");
            }

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Reviews",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genres",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favorites",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Books",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Authors",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Year",
                schema: "dbo",
                table: "Books",
                newName: "WritingYear");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Users",
                type: "uuid",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "dbo",
                table: "Users",
                column: "Id");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reviews",
                schema: "dbo");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Reviews",
                schema: "dbo",
                type: "uuid",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                schema: "dbo",
                table: "Reviews",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Reviews",
                schema: "dbo");

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Reviews",
                schema: "dbo",
                type: "uuid",
                nullable: false);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Reviews",
                type: "uuid",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                schema: "dbo",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Genres",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Genres",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                schema: "dbo",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "Genres");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Genres",
                type: "uuid",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                schema: "dbo",
                table: "Genres",
                column: "Id");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favorites",
                schema: "dbo");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Favorites",
                schema: "dbo",
                type: "uuid",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                schema: "dbo",
                table: "Favorites",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Favorites",
                schema: "dbo");

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Favorites",
                schema: "dbo",
                type: "uuid",
                nullable: false);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                schema: "dbo",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "Favorites");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Favorites",
                type: "uuid",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                schema: "dbo",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Books",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                schema: "dbo",
                table: "Books",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                schema: "dbo",
                table: "Books",
                type: "character varying(17)",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Books",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books",
                schema: "dbo");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                schema: "dbo",
                type: "uuid",
                nullable: false);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "dbo",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Books",
                type: "uuid",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "dbo",
                table: "Books",
                column: "Id");

            migrationBuilder.AddColumn<int>(
                name: "PublishingYear",
                schema: "dbo",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "dbo",
                table: "Authors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Authors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                schema: "dbo",
                table: "Authors",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                schema: "dbo",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "Authors");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Authors",
                type: "uuid",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                schema: "dbo",
                table: "Authors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookGenres",
                schema: "dbo",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BookGenres_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "dbo",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "dbo",
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { new Guid("c948e2a5-ebd5-48e5-8661-4704fe363ad2"), "admin@test.com", "Pass123", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Reviews_Rating",
                schema: "dbo",
                table: "Reviews",
                sql: "\"Rating\" BETWEEN 1 AND 5");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreId",
                schema: "dbo",
                table: "BookGenres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                schema: "dbo",
                table: "Books",
                column: "AuthorId",
                principalSchema: "dbo",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Books_BookId",
                schema: "dbo",
                table: "Favorites",
                column: "BookId",
                principalSchema: "dbo",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                schema: "dbo",
                table: "Favorites",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "dbo",
                table: "Reviews",
                column: "BookId",
                principalSchema: "dbo",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                schema: "dbo",
                table: "Reviews",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                schema: "dbo",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Books_BookId",
                schema: "dbo",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                schema: "dbo",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "BookGenres",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Reviews_Rating",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("c948e2a5-ebd5-48e5-8661-4704fe363ad2"));

            migrationBuilder.DropColumn(
                name: "PublishingYear",
                schema: "dbo",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "WritingYear",
                schema: "dbo",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "Year",
                schema: "dbo",
                table: "Books",
                nullable: true);

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Reviews",
                schema: "dbo",
                newName: "Reviews",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Genres",
                schema: "dbo",
                newName: "Genres",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Favorites",
                schema: "dbo",
                newName: "Favorites",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "dbo",
                newName: "Books",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Authors",
                schema: "dbo",
                newName: "Authors",
                newSchema: "public");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reviews",
                type: "integer",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reviews",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Reviews",
                type: "integer",
                nullable: false);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Reviews",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Genres",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Genres",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Favorites",
                type: "integer",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Favorites",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Favorites",
                type: "integer",
                nullable: false);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Favorites",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(17)",
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "integer",
                nullable: false);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Books",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Authors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Authors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Authors",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "integer", nullable: false),
                    GenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Books_BookId",
                table: "Favorites",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
