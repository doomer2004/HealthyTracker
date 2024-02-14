using AutoMapper;
using HealthyTracker.BLL.Services.DailyService.Interfaces;
using HealthyTracker.BLL.Services.MealService.Interfaces;
using HealthyTracker.Common.Enums;
using HealthyTracker.Common.Models.DTOs.Calories;
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
    

    public async Task<bool> CheckDailyAsync(Guid userId, DateTime date)
    {
        var daily = await _dailyRepository.Table.FirstOrDefaultAsync(d => d.UserId == userId && d.Date == date);
        if (daily is null)
            return false;
            
        var meals = await _mealService.GetUserMealAsync(userId, date);
        var nutrition = new GetNutritionDTO();
        foreach (var temp in meals)
        {
            foreach (var prod in temp.Products)
            {
                nutrition.Calories += prod.Calories;
                nutrition.Protein += prod.Protein;
                nutrition.Fat += prod.Fat;
                nutrition.Carbs += prod.Carbs;
            }
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

    /*public async Task UpdateAsync(Guid userId, DateTime date)
    {
        var daily = await _dailyRepository
            .Table
            .Include(d => d.Meals)
            .FirstOrDefaultAsync(d => d.UserId == userId && d.Date == date);
        
        if (daily is null)
        {
            var newDaily = new Daily
            {
                UserId = userId,
                Date = date,
                NormIsFulfilled = false,
                Meals = new List<Meal>(3)
                {
                    new Meal()
                    {
                        Type = "Breakfast",
                        Products = new List<Product>()
                    },
                    new Meal()
                    {
                        Type = "Lunch",
                        Products = new List<Product>()
                    },
                    new Meal()
                    {
                        Type = "Dinner",
                        Products = new List<Product>()
                    }
                    
                }
            };
            
            await _dailyRepository.Insert(newDaily);
            return ;
        }
        
        return;
    }*/

    public async Task<DailyDTO> GetOrCreateAsync(Guid uId, DateTime date)
    {
        var daily = await _dailyRepository
            .Table
            .Include(d => d.Meals)
            .ThenInclude(d => d.Products)
            .FirstOrDefaultAsync(d => d.UserId == uId && d.Date == date);

        if (daily is null)
        {
            var newDaily = new Daily
            {
                UserId = uId,
                Date = date,
                NormIsFulfilled = false,
                Meals = new List<Meal>(3)
                {
                    new Meal()
                    {
                        Type = "Breakfast",
                        Products = new List<Product>()
                    },
                    new Meal()
                    {
                        Type = "Lunch",
                        Products = new List<Product>()
                    },
                    new Meal()
                    {
                        Type = "Dinner",
                        Products = new List<Product>()
                    }

                }
            };
            await _dailyRepository.Insert(newDaily);
        }

        return _mapper.Map<DailyDTO>(daily);
    }
}

            
        
    
