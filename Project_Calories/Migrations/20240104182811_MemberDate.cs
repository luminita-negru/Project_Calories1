using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Calories.Migrations
{
    public partial class MemberDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MealItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "MealItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealItem_MemberId",
                table: "MealItem",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealItem_Member_MemberId",
                table: "MealItem",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealItem_Member_MemberId",
                table: "MealItem");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_MealItem_MemberId",
                table: "MealItem");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "MealItem");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "MealItem");
        }
    }
}
