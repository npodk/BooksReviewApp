using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksReviewApp.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07766a15-a082-458b-bdc4-7e9a6a0a1ed7"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { new Guid("50d32ce5-543b-442d-9ae7-c7442b37acf7"), "defaultUser@test.com", "defaultUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("07766a15-a082-458b-bdc4-7e9a6a0a1ed7"), "admin@test.com", "admin" });
        }
    }
}
