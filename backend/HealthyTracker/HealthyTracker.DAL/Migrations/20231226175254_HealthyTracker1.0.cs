using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyTracker.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HealthyTracker10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaloriesConsumed_Nutrition_NutritionId",
                table: "CaloriesConsumed");

            migrationBuilder.DropTable(
                name: "FoodMeal");

            migrationBuilder.DropIndex(
                name: "IX_CaloriesConsumed_NutritionId",
                table: "CaloriesConsumed");

            migrationBuilder.DropColumn(
                name: "MealType",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "CaloriesConsumed");

            migrationBuilder.AddColumn<Guid>(
                name: "DailyId",
                table: "Meal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Volume",
                table: "Food",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NormIsFulfilled",
                table: "CaloriesConsumed",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserRegistration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsUrlRegenerated = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRegistration_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_DailyId",
                table: "Meal",
                column: "DailyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistration_UserId",
                table: "UserRegistration",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_CaloriesConsumed_DailyId",
                table: "Meal",
                column: "DailyId",
                principalTable: "CaloriesConsumed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_CaloriesConsumed_DailyId",
                table: "Meal");

            migrationBuilder.DropTable(
                name: "UserRegistration");

            migrationBuilder.DropIndex(
                name: "IX_Meal_DailyId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "DailyId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "NormIsFulfilled",
                table: "CaloriesConsumed");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "MealType",
                table: "Meal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "NutritionId",
                table: "CaloriesConsumed",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FoodMeal",
                columns: table => new
                {
                    FoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMeal", x => new { x.FoodsId, x.MealsId });
                    table.ForeignKey(
                        name: "FK_FoodMeal_Food_FoodsId",
                        column: x => x.FoodsId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodMeal_Meal_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaloriesConsumed_NutritionId",
                table: "CaloriesConsumed",
                column: "NutritionId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeal_MealsId",
                table: "FoodMeal",
                column: "MealsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaloriesConsumed_Nutrition_NutritionId",
                table: "CaloriesConsumed",
                column: "NutritionId",
                principalTable: "Nutrition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
