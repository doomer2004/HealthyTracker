using AutoMapper;
using HealthyTracker.Common.Models.DTOs.Calories;
using HealthyTracker.Common.Models.DTOs.Meal;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Entities;

namespace HealthyTracker.Mapping.Profiles;

public class DailyProfile : Profile
{
    public DailyProfile()
    {
        // CreateMap<Product, ProductDTO>();
        //
        // CreateMap<Meal, MealDTO>()
        //     .ForMember(p => p.Products, 
        //         conf => conf.MapFrom(value => value.Products));
        CreateMap<Daily, DailyDTO>()
            .ForMember(p => p.Meals,
                conf => conf.MapFrom(value => value.Meals));
        CreateMap<MealDTO, Meal>();
        CreateMap<DailyDTO, Daily>().ForMember(p => p.Meals, 
            conf => conf.MapFrom(value => value.Meals));;
    }
}