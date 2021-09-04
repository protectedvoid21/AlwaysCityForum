using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations.ForumDb
{
    public partial class identityForumTweak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_ForumUser_ForumUserId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_ForumUser_ForumUserId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_ForumUserId",
                table: "AppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumUser",
                table: "ForumUser");

            migrationBuilder.DropColumn(
                name: "ForumUserId",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "ForumUser",
                newName: "ForumUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumUsers",
                table: "ForumUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_ForumUsers_ForumUserId",
                table: "Threads",
                column: "ForumUserId",
                principalTable: "ForumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threads_ForumUsers_ForumUserId",
                table: "Threads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumUsers",
                table: "ForumUsers");

            migrationBuilder.RenameTable(
                name: "ForumUsers",
                newName: "ForumUser");

            migrationBuilder.AddColumn<int>(
                name: "ForumUserId",
                table: "AppUser",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumUser",
                table: "ForumUser",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_ForumUserId",
                table: "AppUser",
                column: "ForumUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_ForumUser_ForumUserId",
                table: "AppUser",
                column: "ForumUserId",
                principalTable: "ForumUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_ForumUser_ForumUserId",
                table: "Threads",
                column: "ForumUserId",
                principalTable: "ForumUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
