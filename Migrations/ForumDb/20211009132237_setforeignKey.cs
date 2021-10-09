using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations.ForumDb
{
    public partial class setforeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Section",
                table: "Posts",
                newName: "ForumSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForumSectionId",
                table: "Posts",
                newName: "Section");
        }
    }
}
