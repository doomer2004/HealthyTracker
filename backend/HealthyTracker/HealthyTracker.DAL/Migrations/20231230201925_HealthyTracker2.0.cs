using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyTracker.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HealthyTracker20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalorieGoal_Nutrition_NutritionId",
                table: "CalorieGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Nutrition_NutritionId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistration_AspNetUsers_UserId",
                table: "UserRegistration");

            migrationBuilder.DropTable(
                name: "Nutrition");

            migrationBuilder.DropIndex(
                name: "IX_Food_NutritionId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_CalorieGoal_NutritionId",
                table: "CalorieGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRegistration",
                table: "UserRegistration");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "CalorieGoal");

            migrationBuilder.RenameTable(
                name: "UserRegistration",
                newName: "UserRegistrations");

            migrationBuilder.RenameIndex(
                name: "IX_UserRegistration_UserId",
                table: "UserRegistrations",
                newName: "IX_UserRegistrations_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Meal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Caffeine",
                table: "Food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Calories",
                table: "Food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Carbs",
                table: "Food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cellulose",
                table: "Food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fat",
                table: "Food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "MealId",
                table: "Food",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Protein",
                table: "Food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Salt",
                table: "Food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Water",
                table: "Food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Calories",
                table: "CalorieGoal",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Carbs",
                table: "CalorieGoal",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fat",
                table: "CalorieGoal",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Protein",
                table: "CalorieGoal",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRegistrations",
                table: "UserRegistrations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Food_MealId",
                table: "Food",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Meal_MealId",
                table: "Food",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistrations_AspNetUsers_UserId",
                table: "UserRegistrations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Meal_MealId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistrations_AspNetUsers_UserId",
                table: "UserRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_Food_MealId",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRegistrations",
                table: "UserRegistrations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "Caffeine",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Cellulose",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Water",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Calories",
                table: "CalorieGoal");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "CalorieGoal");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "CalorieGoal");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "CalorieGoal");

            migrationBuilder.RenameTable(
                name: "UserRegistrations",
                newName: "UserRegistration");

            migrationBuilder.RenameIndex(
                name: "IX_UserRegistrations_UserId",
                table: "UserRegistration",
                newName: "IX_UserRegistration_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "NutritionId",
                table: "Food",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NutritionId",
                table: "CalorieGoal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRegistration",
                table: "UserRegistration",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Nutrition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caffeine = table.Column<float>(type: "real", nullable: false),
                    Calories = table.Column<float>(type: "real", nullable: false),
                    Carbs = table.Column<float>(type: "real", nullable: false),
                    Cellulose = table.Column<float>(type: "real", nullable: false),
                    Fat = table.Column<float>(type: "real", nullable: false),
                    Protein = table.Column<float>(type: "real", nullable: false),
                    Salt = table.Column<float>(type: "real", nullable: false),
                    Water = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrition", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_NutritionId",
                table: "Food",
                column: "NutritionId");

            migrationBuilder.CreateIndex(
                name: "IX_CalorieGoal_NutritionId",
                table: "CalorieGoal",
                column: "NutritionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalorieGoal_Nutrition_NutritionId",
                table: "CalorieGoal",
                column: "NutritionId",
                principalTable: "Nutrition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Nutrition_NutritionId",
                table: "Food",
                column: "NutritionId",
                principalTable: "Nutrition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistration_AspNetUsers_UserId",
                table: "UserRegistration",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
