using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksReviewApp.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RemovePasswordFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a557d15-8f8f-47b2-92a2-10e145cff75d"));

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "dbo",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { new Guid("07766a15-a082-458b-bdc4-7e9a6a0a1ed7"), "admin@test.com", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07766a15-a082-458b-bdc4-7e9a6a0a1ed7"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Users",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { new Guid("3a557d15-8f8f-47b2-92a2-10e145cff75d"), "admin@test.com", "Pass123", "admin" });
        }
    }
}
