using Microsoft.EntityFrameworkCore.Migrations;

namespace Przepisy_kulinarne_projekt.Data.Migrations
{
    public partial class _12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoGallery_Recipes_RecipeId",
                table: "PhotoGallery");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "PhotoGallery",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoGallery_Recipes_RecipeId",
                table: "PhotoGallery",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoGallery_Recipes_RecipeId",
                table: "PhotoGallery");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "PhotoGallery",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoGallery_Recipes_RecipeId",
                table: "PhotoGallery",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
