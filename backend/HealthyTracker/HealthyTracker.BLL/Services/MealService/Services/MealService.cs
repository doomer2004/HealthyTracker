using AutoMapper;
using HealthyTracker.BLL.Services.MealService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Meal;
using HealthyTracker.Common.Models.DTOs.Nutrition;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using HealthyTracker.DAL.Repositories.Interfaces;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.MealService.Services;

public class MealService : IMealService
{
    private readonly IMapper _mapper;
    private readonly IMealRepository _mealRepository;
    private readonly IProductRepository _productRepository;
    
    public MealService(IMapper mapper, IMealRepository mealRepository,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _mealRepository = mealRepository;
        _productRepository = productRepository;
    }
    
    public async Task AddMealAsync(Guid userId, Guid dailyId)
    {
        var meal = new Meal
        {
            DailyId = dailyId,
            Products = new List<Product>()
        };
        
        await _mealRepository.Insert(meal);
        return;
    }

    public async Task<List<ProductDTO>> GetAllProductsAsync(Guid userId, 
        DateTime date, Guid mealId)
    {
        var products = await _productRepository.GetAll();
        
        return _mapper.Map<List<ProductDTO>>(products);
    }

    public async Task<GetMealNutritionDTO> GetNutritionAsync(Guid userId, Guid mealId)
    {
        var meals = await _mealRepository.Table.Include(u => u.Daily)
            .ThenInclude(u => u.Meals).ThenInclude(p => p.Products).Where(u => u.Daily.UserId == userId).ToListAsync();
        
        var nutrition = new GetMealNutritionDTO();
        foreach (var meal in meals)
        {
            nutrition.Calories += meal.Products.Sum(p => p.Calories);
            nutrition.Protein += meal.Products.Sum(p => p.Protein);
            nutrition.Fat += meal.Products.Sum(p => p.Fat);
            nutrition.Carbs += meal.Products.Sum(p => p.Carbs);
        }
        
        return nutrition;
    }
    

    public async Task<List<MealDTO>> GetUserMealAsync(Guid userId, DateTime date)
    {
        var nutrition = await _mealRepository
            .Table
            .Include(u => u.Daily)
            .ThenInclude(u => u.Meals)
            .ThenInclude(u => u.Products)
            .Where(u => u.Daily.UserId == userId && u.Daily.Date == date)
            .ToListAsync();
        
        return _mapper.Map<List<MealDTO>>(nutrition);
    }
}