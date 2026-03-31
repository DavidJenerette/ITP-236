using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "UserRoles",
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "RoleName",
                value: "Head Programmer");

            migrationBuilder.UpdateData(
                schema: "UserRoles",
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "RoleName",
                value: "Debugger");

            migrationBuilder.UpdateData(
                schema: "UserRoles",
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Name",
                value: "Daniel Gray");

            migrationBuilder.UpdateData(
                schema: "UserRoles",
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Name",
                value: "Neil Jones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "UserRoles",
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "RoleName",
                value: "Beloved");

            migrationBuilder.UpdateData(
                schema: "UserRoles",
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "RoleName",
                value: "American Gods");

            migrationBuilder.UpdateData(
                schema: "UserRoles",
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Name",
                value: "Toni Morrison");

            migrationBuilder.UpdateData(
                schema: "UserRoles",
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Name",
                value: "Neil Gaiman");
        }
    }
}
