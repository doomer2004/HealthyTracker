using AutoMapper;
using HealthyTracker.BLL.Services.ProductService.Interfaces;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Repositories;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.ProductService.Services;

public class ProductActualService : IProductActualService
{
    private readonly IMapper _mapper;
    private readonly ProductActualRepository _productActualRepository;
    
    public ProductActualService(IMapper mapper, ProductActualRepository productActualRepository)
    {
        _mapper = mapper;
        _productActualRepository = productActualRepository;
    }
    

    public async Task<Either<ErrorDTO, ProductActualDTO>> UpdateAsync(Guid userId, ProductActualDTO dto)
    {
        var productActual = await _productActualRepository.Table.FirstOrDefaultAsync(p => p.Id == dto.ProductId);
        if (productActual is null)
            return new NotFoundErrorDTO("Product does not exist");
        
        _mapper.Map(dto, productActual);
        
        await _productActualRepository.Update(productActual);
        
        return _mapper.Map<ProductActualDTO>(productActual);
            
    }

    public async Task<Option<ErrorDTO>> DeleteAsync(Guid userId, Guid productId)
    {
        var productActual = await _productActualRepository.Table.FirstOrDefaultAsync(p => p.Id == productId);
        if (productActual is null)
            return new NotFoundErrorDTO("Product does not exist");
            
        await _productActualRepository.Delete(productActual);
        return Option<ErrorDTO>.None;
    }
}