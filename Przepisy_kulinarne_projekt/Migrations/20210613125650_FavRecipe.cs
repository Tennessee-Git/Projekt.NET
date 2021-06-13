using Microsoft.EntityFrameworkCore.Migrations;

namespace Przepisy_kulinarne_projekt.Migrations
{
    public partial class FavRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteRecipes_Recipes_RecipeId",
                table: "FavouriteRecipes");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "FavouriteRecipes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ApplicationUserId",
                table: "Recipes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteRecipes_Recipes_RecipeId",
                table: "FavouriteRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_ApplicationUserId",
                table: "Recipes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteRecipes_Recipes_RecipeId",
                table: "FavouriteRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_ApplicationUserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ApplicationUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "FavouriteRecipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteRecipes_Recipes_RecipeId",
                table: "FavouriteRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
