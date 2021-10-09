using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations.ForumDb
{
    public partial class relationTweak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ForumUsers_ForumUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ForumUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ForumUserId",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SectionId",
                table: "Posts",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ForumUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "ForumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sections_SectionId",
                table: "Posts",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ForumUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sections_SectionId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SectionId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "ForumUserId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ForumUserId",
                table: "Posts",
                column: "ForumUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ForumUsers_ForumUserId",
                table: "Posts",
                column: "ForumUserId",
                principalTable: "ForumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
