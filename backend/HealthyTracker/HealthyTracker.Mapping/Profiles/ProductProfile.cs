using AutoMapper;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Entities;

namespace HealthyTracker.Mapping.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.productId, opt => opt.MapFrom(src => src.Id));
        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
    }
}