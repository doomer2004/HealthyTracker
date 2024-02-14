using AutoMapper;
using HealthyTracker.Common.Models.DTOs.Meal;
using HealthyTracker.DAL.Entities;

namespace HealthyTracker.Mapping.Profiles;

public class MealProfile : Profile
{
    public MealProfile()
    {
        CreateMap<Meal, MealDTO>();
    }
}