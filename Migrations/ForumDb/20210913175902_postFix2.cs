using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations.ForumDb
{
    public partial class postFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ForumUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sections_SectionId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Posts",
                newName: "ForumUserId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "ForumSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_SectionId",
                table: "Posts",
                newName: "IX_Posts_ForumUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_ForumSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ForumUsers_ForumUserId",
                table: "Posts",
                column: "ForumUserId",
                principalTable: "ForumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sections_ForumSectionId",
                table: "Posts",
                column: "ForumSectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ForumUsers_ForumUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sections_ForumSectionId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ForumUserId",
                table: "Posts",
                newName: "SectionId");

            migrationBuilder.RenameColumn(
                name: "ForumSectionId",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ForumUserId",
                table: "Posts",
                newName: "IX_Posts_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ForumSectionId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

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
    }
}
