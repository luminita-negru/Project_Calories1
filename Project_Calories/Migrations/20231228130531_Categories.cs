using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Calories.Migrations
{
    public partial class Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_CategorieId",
                table: "Food",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Categorie_CategorieId",
                table: "Food",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Categorie_CategorieId",
                table: "Food");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Food_CategorieId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Food");
        }
    }
}
