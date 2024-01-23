using AutoMapper;
using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.DAL.Entities;

namespace HealthyTracker.Mapping.Profiles;

public class NutritionGoalProfile : Profile
{
    public NutritionGoalProfile()
    {
        CreateMap<NutritionGoalDTO, NutritionGoal>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
    }
}