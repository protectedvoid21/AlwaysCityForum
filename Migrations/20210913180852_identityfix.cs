using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations
{
    public partial class identityfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ForumUser_ForumUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ForumPost");

            migrationBuilder.DropTable(
                name: "ForumSection");

            migrationBuilder.DropTable(
                name: "ForumUser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ForumUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ForumUserId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ForumSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForumUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForumPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumPost_ForumSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ForumSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumPost_ForumUser_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "ForumUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ForumUserId",
                table: "AspNetUsers",
                column: "ForumUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPost_AuthorId",
                table: "ForumPost",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPost_SectionId",
                table: "ForumPost",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ForumUser_ForumUserId",
                table: "AspNetUsers",
                column: "ForumUserId",
                principalTable: "ForumUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
