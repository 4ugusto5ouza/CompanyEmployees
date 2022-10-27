using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmployees.Infrastructure.Migrations
{
    public partial class addRolesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a4e7036-a2e4-4c57-af9f-a199f0f636e1", "cdd1896e-1158-47ef-bdbe-75d3ba34f86e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9e7e2ed-465c-420e-8ad6-fb3fd0dc9c35", "1956a5d4-f0fd-41d9-bd5a-d7fe8aaa586d", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a4e7036-a2e4-4c57-af9f-a199f0f636e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9e7e2ed-465c-420e-8ad6-fb3fd0dc9c35");
        }
    }
}
