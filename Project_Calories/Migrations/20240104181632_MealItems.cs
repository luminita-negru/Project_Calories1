using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Calories.Migrations
{
    public partial class MealItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealItem",
                columns: table => new
                {
                    MealItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: true),
                    FoodId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealItem", x => x.MealItemId);
                    table.ForeignKey(
                        name: "FK_MealItem_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId");
                    table.ForeignKey(
                        name: "FK_MealItem_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "MealId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealItem_FoodId",
                table: "MealItem",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_MealItem_MealId",
                table: "MealItem",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealItem");
        }
    }
}
