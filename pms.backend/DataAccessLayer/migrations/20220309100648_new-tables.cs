using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "asset",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_asset_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "link",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_link_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sprint",
                columns: table => new
                {
                    SprintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SprintDuration = table.Column<int>(type: "int", nullable: false),
                    SprintStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sprint", x => x.SprintId);
                });

            migrationBuilder.CreateTable(
                name: "time",
                columns: table => new
                {
                    TimeRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeRecordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeRecordTiming = table.Column<double>(type: "float", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_time", x => x.TimeRecordId);
                    table.ForeignKey(
                        name: "FK_time_task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_SprintId",
                table: "task",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_asset_ProjectId",
                table: "asset",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_link_ProjectId",
                table: "link",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_time_TaskId",
                table: "time",
                column: "TaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_task_sprint_SprintId",
                table: "task",
                column: "SprintId",
                principalTable: "sprint",
                principalColumn: "SprintId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_task_sprint_SprintId",
                table: "task");

            migrationBuilder.DropTable(
                name: "asset");

            migrationBuilder.DropTable(
                name: "link");

            migrationBuilder.DropTable(
                name: "sprint");

            migrationBuilder.DropTable(
                name: "time");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropIndex(
                name: "IX_task_SprintId",
                table: "task");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "task");
        }
    }
}
