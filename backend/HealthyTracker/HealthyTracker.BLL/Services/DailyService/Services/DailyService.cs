using AutoMapper;
using HealthyTracker.BLL.Services.DailyService.Interfaces;
using HealthyTracker.BLL.Services.MealService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Nutrition;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.DailyService.Services;

public class DailyService : IDailyService
{
    private readonly IMapper _mapper;
    private readonly DailyRepository _dailyRepository;
    private readonly IMealService _mealService;
    private readonly NutritionGoalRepository _nutritionGoalRepository;

    public DailyService(IMapper mapper, DailyRepository dailyRepository,
        IMealService mealService, NutritionGoalRepository nutritionGoalRepository)
    {
        _mapper = mapper;
        _dailyRepository = dailyRepository;
        _mealService = mealService;
        _nutritionGoalRepository = nutritionGoalRepository;
    }

    public async Task AddDailyAsync(Guid userId)
    {
        var daily = await _dailyRepository.Table.FirstOrDefaultAsync(d => d.UserId == userId);
        if (daily.Date == DateTime.Now.Date)
            return;
        
        daily.Date = DateTime.Now.Date;
        daily.NormIsFulfilled = false;
        await _dailyRepository.Update(daily);
        return;
    }

    public async Task<string> CheckDailyAsync(Guid userId)
    {
        var daily = await _dailyRepository.Table.FirstOrDefaultAsync(d => d.UserId == userId);
        if (daily is null)
            return "Daily not found";
        var meals = await _mealService.GetUserMealAsync(userId);
        var nutrition = new GetNutritionDTO();
        // var temp = new GetNutritionDTO();
        foreach (var meal in meals)
        {
            //temp = null;
            var temp = new GetNutritionDTO();
            temp = await _mealService.GetNutritionAsync(userId, meal.Id);
            nutrition.Calories += temp.Calories;
            nutrition.Protein += temp.Protein;
            nutrition.Fat += temp.Fat;
            nutrition.Carbs += temp.Carbs;
        }
        
        var goal = await _nutritionGoalRepository.Table.Include(n => n.Nutrition)
            .FirstOrDefaultAsync(u => u.UserId == userId);
        
        if (goal is null)
            return "The norm is not defined";
        if (goal.Nutrition.Calories > nutrition.Calories)
            return $"You have not eaten enough calories(need {goal.Nutrition.Calories} got {nutrition.Calories})";
        if (goal.Nutrition.Protein > nutrition.Protein)
            return $"You have not eaten enough protein(need {goal.Nutrition.Protein} got {nutrition.Protein})";
        if (goal.Nutrition.Fat > nutrition.Fat)
            return $"You have not eaten enough fat(need {goal.Nutrition.Fat} got {nutrition.Fat})";
        if (goal.Nutrition.Carbs > nutrition.Carbs)
            return $"You have not eaten enough carbs(need {goal.Nutrition.Carbs} got {nutrition.Carbs})";
        
        daily.NormIsFulfilled = true;
        await _dailyRepository.Update(daily);
        
        return "Daily is fulfilled";
    }
}