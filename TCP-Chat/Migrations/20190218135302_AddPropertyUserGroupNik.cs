using Microsoft.EntityFrameworkCore.Migrations;

namespace TCP_Chat.Migrations
{
    public partial class AddPropertyUserGroupNik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGroupNik",
                table: "HistoryLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGroupNik",
                table: "HistoryLogs");
        }
    }
}
