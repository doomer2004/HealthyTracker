using HealthyTracker.Common.Models.DTOs.Meal;
using HealthyTracker.Common.Models.DTOs.Nutrition;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Entities;

namespace HealthyTracker.BLL.Services.MealService.Interfaces;

public interface IMealService
{
    Task<List<ProductDTO>> GetAllProductsAsync(Guid userId, 
        DateTime date, Guid mealId);
    Task<GetMealNutritionDTO> GetNutritionAsync(Guid userId, Guid mealId);
    Task<List<Meal>> GetUserMealAsync(Guid userId);
    Task AddMealAsync(Guid userId, Guid dailyId);
}