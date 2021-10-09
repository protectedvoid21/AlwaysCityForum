using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations.ForumDb
{
    public partial class changeSectionName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sections_ForumSectionId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ForumSectionId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ForumSectionId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumSectionId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ForumSectionId",
                table: "Posts",
                column: "ForumSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sections_ForumSectionId",
                table: "Posts",
                column: "ForumSectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
