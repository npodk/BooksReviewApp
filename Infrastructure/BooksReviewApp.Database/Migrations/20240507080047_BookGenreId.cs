using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksReviewApp.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class BookGenreId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c948e2a5-ebd5-48e5-8661-4704fe363ad2"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "BookGenres",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { new Guid("216a099e-4d58-48e1-94f9-802cae040e76"), "admin@test.com", "Pass123", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("216a099e-4d58-48e1-94f9-802cae040e76"));

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "BookGenres");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { new Guid("c948e2a5-ebd5-48e5-8661-4704fe363ad2"), "admin@test.com", "Pass123", "admin" });
        }
    }
}
