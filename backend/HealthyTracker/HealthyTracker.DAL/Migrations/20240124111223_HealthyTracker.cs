using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyTracker.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HealthyTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalorieGoal_AspNetUsers_UserId",
                table: "CalorieGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_CaloriesConsumed_AspNetUsers_UserId",
                table: "CaloriesConsumed");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Meal_MealId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_CaloriesConsumed_DailyId",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaloriesConsumed",
                table: "CaloriesConsumed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalorieGoal",
                table: "CalorieGoal");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "CaloriesConsumed",
                newName: "Daily");

            migrationBuilder.RenameTable(
                name: "CalorieGoal",
                newName: "NutritionGoal");

            migrationBuilder.RenameIndex(
                name: "IX_Food_MealId",
                table: "Product",
                newName: "IX_Product_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_CaloriesConsumed_UserId",
                table: "Daily",
                newName: "IX_Daily_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CalorieGoal_UserId",
                table: "NutritionGoal",
                newName: "IX_NutritionGoal_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Daily",
                table: "Daily",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NutritionGoal",
                table: "NutritionGoal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Daily_AspNetUsers_UserId",
                table: "Daily",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Daily_DailyId",
                table: "Meal",
                column: "DailyId",
                principalTable: "Daily",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionGoal_AspNetUsers_UserId",
                table: "NutritionGoal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Meal_MealId",
                table: "Product",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Daily_AspNetUsers_UserId",
                table: "Daily");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Daily_DailyId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_NutritionGoal_AspNetUsers_UserId",
                table: "NutritionGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Meal_MealId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NutritionGoal",
                table: "NutritionGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Daily",
                table: "Daily");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "NutritionGoal",
                newName: "CalorieGoal");

            migrationBuilder.RenameTable(
                name: "Daily",
                newName: "CaloriesConsumed");

            migrationBuilder.RenameIndex(
                name: "IX_Product_MealId",
                table: "Food",
                newName: "IX_Food_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_NutritionGoal_UserId",
                table: "CalorieGoal",
                newName: "IX_CalorieGoal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Daily_UserId",
                table: "CaloriesConsumed",
                newName: "IX_CaloriesConsumed_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalorieGoal",
                table: "CalorieGoal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaloriesConsumed",
                table: "CaloriesConsumed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalorieGoal_AspNetUsers_UserId",
                table: "CalorieGoal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaloriesConsumed_AspNetUsers_UserId",
                table: "CaloriesConsumed",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Meal_MealId",
                table: "Food",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_CaloriesConsumed_DailyId",
                table: "Meal",
                column: "DailyId",
                principalTable: "CaloriesConsumed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
