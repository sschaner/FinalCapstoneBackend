using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalCapstoneBackend.Migrations
{
    public partial class updatingUserContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteTrails_Users_UserId",
                table: "FavoriteTrails");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteTrails_UserId",
                table: "FavoriteTrails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTrails_UserId",
                table: "FavoriteTrails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteTrails_Users_UserId",
                table: "FavoriteTrails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
