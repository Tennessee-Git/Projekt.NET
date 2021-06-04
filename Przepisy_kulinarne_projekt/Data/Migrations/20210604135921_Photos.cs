using Microsoft.EntityFrameworkCore.Migrations;

namespace Przepisy_kulinarne_projekt.Data.Migrations
{
    public partial class Photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoGallery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoGallery_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoGallery_RecipeId",
                table: "PhotoGallery",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoGallery");
        }
    }
}
