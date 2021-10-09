using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations.ForumDb
{
    public partial class postFix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_ForumUsers_ForumUserId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ForumUsers_ForumUserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "ForumUsers");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ForumUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_ForumUserId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "ForumUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ForumUserId",
                table: "AppUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumUserId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForumUserId",
                table: "AppUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ForumUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ForumUserId",
                table: "Posts",
                column: "ForumUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_ForumUserId",
                table: "AppUser",
                column: "ForumUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_ForumUsers_ForumUserId",
                table: "AppUser",
                column: "ForumUserId",
                principalTable: "ForumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
