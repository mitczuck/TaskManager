using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_ResponsibleUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskHistories_UserId",
                table: "TaskHistories");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ResponsibleUserId",
                table: "Tasks",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_UserId",
                table: "TaskHistories",
                column: "UserId");

            migrationBuilder.Sql("UPDATE Users SET Position = 0 WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Users SET Position = 1 WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Users SET Position = 2 WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Users SET Position = 0 WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Users SET Position = 1 WHERE Id = 5");
            migrationBuilder.Sql("UPDATE Users SET Position = 2 WHERE Id = 6");
            migrationBuilder.Sql("UPDATE Users SET Position = 0 WHERE Id = 7");
            migrationBuilder.Sql("UPDATE Users SET Position = 1 WHERE Id = 8");
            migrationBuilder.Sql("UPDATE Users SET Position = 2 WHERE Id = 9");
            migrationBuilder.Sql("UPDATE Users SET Position = 0 WHERE Id = 10");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_ResponsibleUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskHistories_UserId",
                table: "TaskHistories");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ResponsibleUserId",
                table: "Tasks",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_UserId",
                table: "TaskHistories",
                column: "UserId");
        }
    }
}
