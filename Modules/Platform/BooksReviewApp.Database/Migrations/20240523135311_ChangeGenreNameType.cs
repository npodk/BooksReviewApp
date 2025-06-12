using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksReviewApp.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGenreNameType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("216a099e-4d58-48e1-94f9-802cae040e76"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { new Guid("7a6bfb7c-dc8e-4d67-99e4-b748855dde10"), "admin@test.com", "Pass123", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                schema: "dbo",
                table: "Genres",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                schema: "dbo",
                table: "Genres");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7a6bfb7c-dc8e-4d67-99e4-b748855dde10"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { new Guid("216a099e-4d58-48e1-94f9-802cae040e76"), "admin@test.com", "Pass123", "admin" });
        }
    }
}
