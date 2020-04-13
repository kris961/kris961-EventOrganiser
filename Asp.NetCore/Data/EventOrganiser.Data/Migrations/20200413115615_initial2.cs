namespace EventOrganiser.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWhitelisted",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "Entry",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entry",
                table: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "IsWhitelisted",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
