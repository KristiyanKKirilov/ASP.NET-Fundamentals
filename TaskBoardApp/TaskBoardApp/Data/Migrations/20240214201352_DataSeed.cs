using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Board identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Board name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Task identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Task title"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Task description"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Task date of creation"),
                    BoardId = table.Column<int>(type: "int", nullable: false, comment: "Task's board identifier"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Application user's identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Board tasks");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bce4ed90-360e-4fb4-9862-2f0fa0b4aee0", 0, "590b29ac-98a5-4f96-bc26-97255338bed0", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEF8D3kTTvXZk6oDyBGz4YMaAaPuJHTKIWtMRwEZVqqUeXvkAc4XBWHS6EF+di/BQhw==", null, false, "dbe4033d-3827-40c3-9cca-075db08f761e", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 29, 22, 13, 52, 323, DateTimeKind.Local).AddTicks(7363), "Implement better styling for all public pages", "bce4ed90-360e-4fb4-9862-2f0fa0b4aee0", "Improve CSS styles" },
                    { 2, 1, new DateTime(2024, 2, 9, 22, 13, 52, 323, DateTimeKind.Local).AddTicks(7397), "Create Android client app for the TaskBoard RESTful API", "bce4ed90-360e-4fb4-9862-2f0fa0b4aee0", "Android Client App" },
                    { 3, 2, new DateTime(2024, 2, 13, 22, 13, 52, 323, DateTimeKind.Local).AddTicks(7400), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "bce4ed90-360e-4fb4-9862-2f0fa0b4aee0", "Desktop Client App" },
                    { 4, 2, new DateTime(2024, 2, 13, 22, 13, 52, 323, DateTimeKind.Local).AddTicks(7402), "Implement [Create Task] page for adding new tasks", "bce4ed90-360e-4fb4-9862-2f0fa0b4aee0", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bce4ed90-360e-4fb4-9862-2f0fa0b4aee0");
        }
    }
}
