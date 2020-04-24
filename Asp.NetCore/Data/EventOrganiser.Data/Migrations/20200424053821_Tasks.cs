using Microsoft.EntityFrameworkCore.Migrations;

namespace EventOrganiser.Data.Migrations
{
    public partial class Tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Events_EventId1",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_AspNetUsers_InvitedId1",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_AspNetUsers_InviterId1",
                table: "Invites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersEvents",
                table: "UsersEvents");

            migrationBuilder.DropIndex(
                name: "IX_UsersEvents_EventId",
                table: "UsersEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invites",
                table: "Invites");

            migrationBuilder.RenameTable(
                name: "Invites",
                newName: "Invite");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_InviterId1",
                table: "Invite",
                newName: "IX_Invite_InviterId1");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_InvitedId1",
                table: "Invite",
                newName: "IX_Invite_InvitedId1");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_EventId1",
                table: "Invite",
                newName: "IX_Invite_EventId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersEvents",
                table: "UsersEvents",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invite",
                table: "Invite",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: false),
                    Job = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Tasks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersEvents_UserId",
                table: "UsersEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Events_EventId1",
                table: "Invite",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_AspNetUsers_InvitedId1",
                table: "Invite",
                column: "InvitedId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_AspNetUsers_InviterId1",
                table: "Invite",
                column: "InviterId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Events_EventId1",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_AspNetUsers_InvitedId1",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_AspNetUsers_InviterId1",
                table: "Invite");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersEvents",
                table: "UsersEvents");

            migrationBuilder.DropIndex(
                name: "IX_UsersEvents_UserId",
                table: "UsersEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invite",
                table: "Invite");

            migrationBuilder.RenameTable(
                name: "Invite",
                newName: "Invites");

            migrationBuilder.RenameIndex(
                name: "IX_Invite_InviterId1",
                table: "Invites",
                newName: "IX_Invites_InviterId1");

            migrationBuilder.RenameIndex(
                name: "IX_Invite_InvitedId1",
                table: "Invites",
                newName: "IX_Invites_InvitedId1");

            migrationBuilder.RenameIndex(
                name: "IX_Invite_EventId1",
                table: "Invites",
                newName: "IX_Invites_EventId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersEvents",
                table: "UsersEvents",
                columns: new[] { "UserId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invites",
                table: "Invites",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersEvents_EventId",
                table: "UsersEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Events_EventId1",
                table: "Invites",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_AspNetUsers_InvitedId1",
                table: "Invites",
                column: "InvitedId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_AspNetUsers_InviterId1",
                table: "Invites",
                column: "InviterId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
