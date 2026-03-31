using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core_1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UserRoles");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                schema: "UserRoles",
                columns: table => new
                {
                    RolesRoleId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => new { x.RolesRoleId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalSchema: "UserRoles",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalSchema: "UserRoles",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "UserRoles",
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Beloved" },
                    { 2, "American Gods" }
                });

            migrationBuilder.InsertData(
                schema: "UserRoles",
                table: "Users",
                columns: new[] { "UserId", "Name" },
                values: new object[,]
                {
                    { 1, "Toni Morrison" },
                    { 2, "Neil Gaiman" }
                });

            migrationBuilder.InsertData(
                schema: "UserRoles",
                table: "UsersRoles",
                columns: new[] { "RolesRoleId", "UsersUserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UsersUserId",
                schema: "UserRoles",
                table: "UsersRoles",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRoles",
                schema: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "UserRoles");
        }
    }
}
