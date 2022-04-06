using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalCapstoneBackend.Migrations
{
    public partial class updatedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteTrails",
                table: "FavoriteTrails");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "FavoriteTrails");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FavoriteTrails",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteTrails",
                table: "FavoriteTrails",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteTrails_Users_UserId",
                table: "FavoriteTrails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteTrails",
                table: "FavoriteTrails");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteTrails_UserId",
                table: "FavoriteTrails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FavoriteTrails");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "FavoriteTrails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteTrails",
                table: "FavoriteTrails",
                column: "MyProperty");
        }
    }
}
