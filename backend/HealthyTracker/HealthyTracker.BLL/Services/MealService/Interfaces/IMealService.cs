using HealthyTracker.Common.Models.DTOs.Nutrition;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Entities;

namespace HealthyTracker.BLL.Services.MealService.Interfaces;

public interface IMealService
{
    Task<List<ProductActualDTO>> GetAllProductsAsync(Guid userId, 
        DateTime date, Guid mealId);
    Task<GetNutritionDTO> GetNutritionAsync(Guid userId, Guid mealId);
    Task<List<Meal>> GetUserMealAsync(Guid userId);
}