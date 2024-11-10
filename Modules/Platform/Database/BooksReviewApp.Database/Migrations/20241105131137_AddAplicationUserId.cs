using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksReviewApp.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddAplicationUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18ba8366-df77-441f-9154-1c897892c449"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "ApplicationUserId", "Email", "Username" },
                values: new object[] { new Guid("e4c25a90-2ae9-4699-a717-4db0d96461a2"), new Guid("18ba8366-df77-441f-9154-1c897892c449"), "admin@example.com", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4c25a90-2ae9-4699-a717-4db0d96461a2"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[] { new Guid("18ba8366-df77-441f-9154-1c897892c449"), "admin@example.com", "admin" });
        }
    }
}
