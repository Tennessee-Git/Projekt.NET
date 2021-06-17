using Microsoft.EntityFrameworkCore.Migrations;

namespace Przepisy_kulinarne_projekt.Migrations
{
    public partial class Ulubione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    PersonId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavRecipes_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavRecipes_PersonId",
                table: "FavRecipes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FavRecipes_RecipeId",
                table: "FavRecipes",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavRecipes");
        }
    }
}
