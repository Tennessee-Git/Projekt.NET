using Microsoft.EntityFrameworkCore.Migrations;

namespace Przepisy_kulinarne_projekt.Data.Migrations
{
    public partial class recipecategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategory_Categories_CategoryId",
                table: "RecipeCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategory_Recipes_RecipeId",
                table: "RecipeCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeCategory",
                table: "RecipeCategory");

            migrationBuilder.RenameTable(
                name: "RecipeCategory",
                newName: "RecipeCategories");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeCategory_RecipeId",
                table: "RecipeCategories",
                newName: "IX_RecipeCategories_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeCategory_CategoryId",
                table: "RecipeCategories",
                newName: "IX_RecipeCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeCategories",
                table: "RecipeCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Recipes_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Recipes_RecipeId",
                table: "RecipeCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeCategories",
                table: "RecipeCategories");

            migrationBuilder.RenameTable(
                name: "RecipeCategories",
                newName: "RecipeCategory");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeCategories_RecipeId",
                table: "RecipeCategory",
                newName: "IX_RecipeCategory_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeCategories_CategoryId",
                table: "RecipeCategory",
                newName: "IX_RecipeCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeCategory",
                table: "RecipeCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategory_Categories_CategoryId",
                table: "RecipeCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategory_Recipes_RecipeId",
                table: "RecipeCategory",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
