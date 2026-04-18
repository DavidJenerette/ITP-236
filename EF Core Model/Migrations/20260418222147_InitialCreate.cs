using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core_Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UserRoles_Updated");

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "UserRoles_Updated",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "UserRoles_Updated",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "UserRoles_Updated",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WorkItems",
                schema: "UserRoles_Updated",
                columns: table => new
                {
                    WorkItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.WorkItemId);
                    table.ForeignKey(
                        name: "FK_WorkItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "UserRoles_Updated",
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                schema: "UserRoles_Updated",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoursPerWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "UserRoles_Updated",
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjects_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserRoles_Updated",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                schema: "UserRoles_Updated",
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
                        principalSchema: "UserRoles_Updated",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalSchema: "UserRoles_Updated",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "UserRoles_Updated",
                table: "Projects",
                columns: new[] { "ProjectId", "Budget", "ProjectName" },
                values: new object[,]
                {
                    { 1, 2500m, "Inventory System" },
                    { 2, 1800m, "Bug Tracker" }
                });

            migrationBuilder.InsertData(
                schema: "UserRoles_Updated",
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Head Programmer" },
                    { 2, "Debugger" }
                });

            migrationBuilder.InsertData(
                schema: "UserRoles_Updated",
                table: "Users",
                columns: new[] { "UserId", "Department", "Name" },
                values: new object[,]
                {
                    { 1, "Engineering", "Daniel Gray" },
                    { 2, "QA", "Neil Jones" }
                });

            migrationBuilder.InsertData(
                schema: "UserRoles_Updated",
                table: "UserProjects",
                columns: new[] { "ProjectId", "UserId", "AssignedOn", "HoursPerWeek" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 2, 2, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 }
                });

            migrationBuilder.InsertData(
                schema: "UserRoles_Updated",
                table: "UsersRoles",
                columns: new[] { "RolesRoleId", "UsersUserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "UserRoles_Updated",
                table: "WorkItems",
                columns: new[] { "WorkItemId", "IsCompleted", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1, false, 1, "Build Login" },
                    { 2, false, 2, "Fix Search Bug" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                schema: "UserRoles_Updated",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UsersUserId",
                schema: "UserRoles_Updated",
                table: "UsersRoles",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_ProjectId",
                schema: "UserRoles_Updated",
                table: "WorkItems",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProjects",
                schema: "UserRoles_Updated");

            migrationBuilder.DropTable(
                name: "UsersRoles",
                schema: "UserRoles_Updated");

            migrationBuilder.DropTable(
                name: "WorkItems",
                schema: "UserRoles_Updated");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "UserRoles_Updated");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "UserRoles_Updated");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "UserRoles_Updated");
        }
    }
}
