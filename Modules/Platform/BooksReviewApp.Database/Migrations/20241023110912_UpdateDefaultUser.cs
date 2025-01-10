using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksReviewApp.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50d32ce5-543b-442d-9ae7-c7442b37acf7"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { new Guid("18ba8366-df77-441f-9154-1c897892c449"), "admin@example.com", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18ba8366-df77-441f-9154-1c897892c449"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { new Guid("50d32ce5-543b-442d-9ae7-c7442b37acf7"), "defaultUser@test.com", "defaultUser" });
        }
    }
}
