using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friends" },
                    { 3, "Work" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 3, "john@example.com", "John", "Doe", "1234567890" },
                    { 2, 2, "aziz@example.com", "Aziz", "Najjar", "0987654321" },
                    { 3, 1, "alex@example.com", "Alex", "Spakova", "0987654321" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
