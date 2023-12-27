using AutoMapper;
using HealthyTracker.BLL.Services.NutritionService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.NutritionService.Services;

public class NutritionGoalService : INutritionGoalService
{
    private readonly NutritionGoalRepository _nutritionGoalRepository;
    private readonly NutritionRepository _nutritionRepository;
    private readonly IMapper _mapper;

    public NutritionGoalService(NutritionGoalRepository nutritionGoalRepository, 
        IMapper mapper, NutritionRepository nutritionRepository)
    {
        _nutritionGoalRepository = nutritionGoalRepository;
        _mapper = mapper;
        _nutritionRepository = nutritionRepository;
    }
    
    public async Task<Either<ErrorDTO, NutritionGoalDTO>> GetAsync(Guid userId)
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

    private async Task<Either<ErrorDTO, NutritionGoalDTO>> AddAsync(Guid userId, NutritionGoalDTO dto)
    {
        var goal = await _nutritionGoalRepository.Table.FirstOrDefaultAsync(g => g.UserId == userId); ;
        if (goal is null)
            return new NotFoundErrorDTO("User with this id does not exist");
        
        var nutrition = _mapper.Map<Nutrition>(dto.Nutrition);
        await _nutritionRepository.Insert(nutrition);
        var newGoal = new NutritionGoal{ UserId = userId, NutritionId = nutrition.Id };
        await _nutritionGoalRepository.Insert(newGoal);

        return _mapper.Map<NutritionGoalDTO>(newGoal);
    }

    private async Task<Either<ErrorDTO, NutritionGoalDTO>> UpdateAsync(Guid userId, NutritionGoalDTO dto)
    {
        var goal = await _nutritionGoalRepository.Table.FirstOrDefaultAsync(g => g.UserId == userId);
        if (goal is null)
            return new NotFoundErrorDTO("User with this id does not exist");
        
        var nutrition = _mapper.Map<Nutrition>(dto.Nutrition);
        await _nutritionRepository.Table.FirstOrDefaultAsync(u => u.Id == goal.NutritionId);
        await _nutritionRepository.Update(nutrition);
        
        return _mapper.Map<NutritionGoalDTO>(goal);
    }
}