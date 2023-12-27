using AutoMapper;
using HealthyTracker.BLL.Services.ProductActualService.Interfaces;
using HealthyTracker.BLL.Services.ProductService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Repositories;
using LanguageExt;

namespace HealthyTracker.BLL.Services.ProductActualService.Services;

public class ProductActualService : IProductActualService
{
    private readonly IMapper _mapper;
    private readonly ProductActualRepository _productActualRepository;
    
    public ProductActualService(IMapper mapper, ProductActualRepository productActualRepository)
    {
        _mapper = mapper;
        _productActualRepository = productActualRepository;
    }
    
    
    public Task<ProductActualDTO> GetAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Guid userId, ProductActualDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid userId, ProductActualDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}