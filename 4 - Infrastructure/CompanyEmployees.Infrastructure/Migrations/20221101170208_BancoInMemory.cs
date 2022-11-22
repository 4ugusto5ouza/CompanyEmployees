using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmployees.Infrastructure.Migrations
{
    public partial class BancoInMemory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02fb2728-4fce-42db-9388-445d24c61ae3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58f1bfd0-e5f1-4007-a55d-04ce74678497");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "824d973f-7ae6-4d76-8eb1-4ff5b04e1fb8", "ba9f35f0-99e4-4ab3-a22c-b3211ef9dbf4", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0f838a1-a279-4987-a601-51889e218d3c", "819f57e3-eb8d-4faa-b4d3-dd8d1bb0f761", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824d973f-7ae6-4d76-8eb1-4ff5b04e1fb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0f838a1-a279-4987-a601-51889e218d3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02fb2728-4fce-42db-9388-445d24c61ae3", "2893eefd-3c62-4171-82dd-89ba6d9de31c", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58f1bfd0-e5f1-4007-a55d-04ce74678497", "75027e24-e5ac-4352-9cd5-3e8b1dff1c25", "Administrator", "ADMINISTRATOR" });
        }
    }
}
