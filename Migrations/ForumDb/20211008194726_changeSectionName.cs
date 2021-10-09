using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations.ForumDb
{
    public partial class changeSectionName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sections_SectionId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Posts",
                newName: "ForumSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_SectionId",
                table: "Posts",
                newName: "IX_Posts_ForumSectionId");

            migrationBuilder.AddColumn<int>(
                name: "Section",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sections_ForumSectionId",
                table: "Posts",
                column: "ForumSectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sections_ForumSectionId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ForumSectionId",
                table: "Posts",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ForumSectionId",
                table: "Posts",
                newName: "IX_Posts_SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sections_SectionId",
                table: "Posts",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
