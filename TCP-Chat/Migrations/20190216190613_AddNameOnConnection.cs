using Microsoft.EntityFrameworkCore.Migrations;

namespace TCP_Chat.Migrations
{
    public partial class AddNameOnConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Connections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Connections");
        }
    }
}
