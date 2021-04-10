using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagment.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignedUsers",
                columns: table => new
                {
                    AssignedUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedUsers", x => x.AssignedUserId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskUnitId);
                });

            migrationBuilder.CreateTable(
                name: "AssignedUserTaskUnits",
                columns: table => new
                {
                    AssignedUserId = table.Column<int>(type: "int", nullable: false),
                    TaskUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedUserTaskUnits", x => new { x.AssignedUserId, x.TaskUnitId });
                    table.ForeignKey(
                        name: "FK_AssignedUserTaskUnits_AssignedUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AssignedUsers",
                        principalColumn: "AssignedUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedUserTaskUnits_Tasks_TaskUnitId",
                        column: x => x.TaskUnitId,
                        principalTable: "Tasks",
                        principalColumn: "TaskUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedUserTaskUnits_TaskUnitId",
                table: "AssignedUserTaskUnits",
                column: "TaskUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedUserTaskUnits");

            migrationBuilder.DropTable(
                name: "AssignedUsers");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
