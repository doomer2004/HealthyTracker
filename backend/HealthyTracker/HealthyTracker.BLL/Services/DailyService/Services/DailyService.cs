using AutoMapper;
using HealthyTracker.BLL.Services.DailyService.Interfaces;
using HealthyTracker.BLL.Services.MealService.Interfaces;
using HealthyTracker.Common.Enums;
using HealthyTracker.Common.Models.DTOs.Nutrition;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using HealthyTracker.DAL.Repositories.Interfaces;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.DailyService.Services;

public class DailyService : IDailyService
{
    private readonly IMapper _mapper;
    private readonly IDailyRepository _dailyRepository;
    private readonly IMealService _mealService;
    private readonly INutritionGoalRepository _nutritionGoalRepository;

    public DailyService(IMapper mapper, IDailyRepository dailyRepository,
        IMealService mealService, INutritionGoalRepository nutritionGoalRepository)
    {
        _mapper = mapper;
        _dailyRepository = dailyRepository;
        _mealService = mealService;
        _nutritionGoalRepository = nutritionGoalRepository;
    }
    

    public async Task<bool> CheckDailyAsync(Guid userId)
    {
        var daily = await _dailyRepository.Table.FirstOrDefaultAsync(d => d.UserId == userId);
        if (daily is null)
            return false;
            
        var meals = await _mealService.GetUserMealAsync(userId);
        var nutrition = new GetNutritionDTO();
        foreach (var temp in meals.Select(meal => _mapper.Map<GetNutritionDTO>(meal)))
        {
            nutrition.Calories += temp.Calories;
            nutrition.Protein += temp.Protein;
            nutrition.Fat += temp.Fat;
            nutrition.Carbs += temp.Carbs;
        }
        
        var goal = await _nutritionGoalRepository.Table.FirstOrDefaultAsync(g => g.UserId == userId);
        
        if (goal is null)
        {
            daily.NormIsFulfilled = false;
            return false;
        }
            //return "The norm is not defined";
        if (goal.Calories > nutrition.Calories)
        {
            daily.NormIsFulfilled = false;
            return false;
        }
            //return $"You have not eaten enough calories(need {goal.Calories} got {nutrition.Calories})";
        if (goal.Protein > nutrition.Protein)
        {
            daily.NormIsFulfilled = false;
            return false;
        }
            //return $"You have not eaten enough protein(need {goal.Protein} got {nutrition.Protein})";
        if (goal.Fat > nutrition.Fat)
        {
            daily.NormIsFulfilled = false;
            return false;
        }
            //return $"You have not eaten enough fat(need {goal.Fat} got {nutrition.Fat})";
        if (goal.Carbs > nutrition.Carbs)
        {
            daily.NormIsFulfilled = false;
            return false;
        }
            //return $"You have not eaten enough carbs(need {goal.Carbs} got {nutrition.Carbs})";
        
        daily.NormIsFulfilled = true;
        await _dailyRepository.Update(daily);
        
        return true;
        //return "Daily is fulfilled";
    }
}