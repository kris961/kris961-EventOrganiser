using Microsoft.EntityFrameworkCore.Migrations;

namespace EventOrganiser.Data.Migrations
{
    public partial class UpdateReplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Replies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Replies");
        }
    }
}
