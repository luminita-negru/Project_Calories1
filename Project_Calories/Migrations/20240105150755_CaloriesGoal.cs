using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Calories.Migrations
{
    public partial class CaloriesGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaloriesGoal",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesGoal",
                table: "Member");
        }
    }
}
