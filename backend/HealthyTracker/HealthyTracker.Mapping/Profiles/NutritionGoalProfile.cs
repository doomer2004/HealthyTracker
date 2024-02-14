using AutoMapper;
using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.DAL.Entities;

namespace HealthyTracker.Mapping.Profiles;

public class NutritionGoalProfile : Profile
{
    public NutritionGoalProfile()
    {
        CreateMap<NutritionGoalDTO, NutritionGoal>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Carbs, opt => opt.MapFrom(src => src.Carbohydrates))
            .ForMember(dest => dest.Protein, opt => opt.MapFrom(src => src.Proteins));
        
        CreateMap<NutritionGoal, NutritionGoalDTO>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Carbohydrates, opt => opt.MapFrom(src => src.Carbs))
            .ForMember(dest => dest.Proteins, opt => opt.MapFrom(src => src.Protein));
        
    }
}