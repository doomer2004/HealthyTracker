using AutoMapper;
using HealthyTracker.BLL.Services.MealService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Meal;
using HealthyTracker.Common.Models.DTOs.Nutrition;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.MealService.Services;

public class MealService : IMealService
{
    private readonly IMapper _mapper;
    private readonly MealRepository _mealRepository;
    private readonly ProductActualRepository _productRepository;
    
    public MealService(IMapper mapper, MealRepository mealRepository,
        ProductActualRepository productRepository)
    {
        _mapper = mapper;
        _mealRepository = mealRepository;
        _productRepository = productRepository;
    }

    public async Task<List<ProductActualDTO>> GetAllProductsAsync(Guid userId, 
        DateTime date, Guid mealId)
    {
        var products = await _productRepository.Table.Include(p => p.ProductId)
            .Where(p => p.MealId == mealId).ToListAsync();
        
        return _mapper.Map<List<ProductActualDTO>>(products);
    }

    public async Task<GetNutritionDTO> GetNutritionAsync(Guid userId, Guid mealId)
    {
        var meals = await _productRepository.Table.Include(m => m.MealId)
            .Where(p => p.MealId == mealId).ToListAsync();
        
        var nutrition = new GetNutritionDTO();
        foreach (var meal in meals)
        {
            nutrition.Calories += meal.Product.Nutrition.Calories;
            nutrition.Protein += meal.Product.Nutrition.Protein;
            nutrition.Fat += meal.Product.Nutrition.Fat;
            nutrition.Carbs += meal.Product.Nutrition.Carbs;
        }
        
        return nutrition;
    }

    public async Task<List<Meal>> GetUserMealAsync(Guid userId)
    {
        var nutrition = await _mealRepository.Table.Include(u => u.Daily)
            .ThenInclude(d => d.UserId).Where(u => u.Daily.UserId == userId).ToListAsync();
        
        return nutrition;
    }
}