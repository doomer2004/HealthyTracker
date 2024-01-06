using HealthyTracker.Client.Nutrition.Models.Requests;
using HealthyTracker.Client.Nutrition.Models.Responses;

namespace HealthyTracker.Client.Nutrition;

public interface INutritionsClient
{
    public Task<GetNutritionByNameResponse?> GetNutritionsByNameAsync(GetNutritionByNameRequest request);
}
