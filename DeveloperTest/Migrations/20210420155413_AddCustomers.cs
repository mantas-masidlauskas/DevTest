using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperTest.Migrations
{
    public partial class AddCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name", "TypeId" },
                values: new object[] { 1, "Small customer", (byte)0 });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name", "TypeId" },
                values: new object[] { 2, "Large customer", (byte)1 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "When",
                value: new DateTime(2021, 4, 20, 16, 54, 12, 836, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "CustomerId", "Engineer", "When" },
                values: new object[] { 2, 2, "Test", new DateTime(2021, 4, 20, 16, 54, 12, 841, DateTimeKind.Local).AddTicks(3290) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "When",
                value: new DateTime(2021, 4, 20, 14, 59, 39, 861, DateTimeKind.Local).AddTicks(3138));
        }
    }
}
