using Microsoft.EntityFrameworkCore.Migrations;

namespace Przepisy_kulinarne_projekt.Data.Migrations
{
    public partial class DeletedImageFromRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Recipes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
