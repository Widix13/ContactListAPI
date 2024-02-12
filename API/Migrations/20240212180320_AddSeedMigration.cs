using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "Category", "Email", "Name", "Password", "PhoneNumber", "Subcategory", "Surname" },
                values: new object[] { 1, new DateTime(2024, 2, 12, 19, 3, 20, 46, DateTimeKind.Local).AddTicks(5453), 0, "admin@admin", "admin", "$2a$11$olSey4.HH9It3sLRhVfK8OYKnqh2idxHdaEFhfU1QNcu3di2RhMce", "123456789", "Business", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
