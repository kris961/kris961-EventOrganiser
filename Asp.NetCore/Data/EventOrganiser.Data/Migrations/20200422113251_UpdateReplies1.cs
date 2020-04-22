using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventOrganiser.Data.Migrations
{
    public partial class UpdateReplies1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Replies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Replies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedOn",
                table: "Replies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Replies");
        }
    }
}
