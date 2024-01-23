using AutoMapper;
using HealthyTracker.BLL.Services.NutritionService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using HealthyTracker.DAL.Repositories.Interfaces;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.NutritionService.Services;

public class NutritionGoalService : INutritionGoalService
{
    private readonly INutritionGoalRepository _nutritionGoalRepository;
    private readonly IMapper _mapper;

    public NutritionGoalService(INutritionGoalRepository nutritionGoalRepository, 
        IMapper mapper)
    {
        _nutritionGoalRepository = nutritionGoalRepository;
        _mapper = mapper;
    }
    
    public async Task<Either<ErrorDto, NutritionGoalDTO>> GetAsync(Guid userId)
    {
        var goal = await _nutritionGoalRepository.Table.Include(u => u.User)
            .FirstOrDefaultAsync(u => u.UserId == userId);

        if (goal is null)
            return new NotFoundErrorDTO("User with this id does not exist");
        
        return _mapper.Map<NutritionGoalDTO>(goal);
    }
    
    public async Task SaveAsync(Guid userId, NutritionGoalDTO dto)
    {
            var goal = await _nutritionGoalRepository.Table.FirstOrDefaultAsync(g => g.UserId == userId); ;
            if (goal is null)
            {
                await AddAsync(userId, dto);
                return; 
            }

            await UpdateAsync(userId, dto);
    }

    private async Task<bool> AddAsync(Guid userId, NutritionGoalDTO dto)
    {
        var newGoal = _mapper.Map<NutritionGoal>(dto);
        newGoal.UserId = userId;
        await _nutritionGoalRepository.Insert(newGoal);
        return true;
    }

    private async Task<bool> UpdateAsync(Guid userId, NutritionGoalDTO dto)
    {
        var nutrition = _mapper.Map<NutritionGoal>(dto);
        await _nutritionGoalRepository.Update(nutrition);
        
        return true;
    }
}