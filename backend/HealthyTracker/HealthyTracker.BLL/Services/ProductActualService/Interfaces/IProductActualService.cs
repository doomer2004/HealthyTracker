using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.Product;
using LanguageExt;

namespace HealthyTracker.BLL.Services.ProductActualService.Interfaces;

public interface IProductActualService
{
    Task<ProductActualDTO> GetAsync(Guid userId);
    Task AddAsync(Guid userId, ProductActualDTO dto);
    Task UpdateAsync(Guid userId, ProductActualDTO dto);
    Task DeleteAsync(Guid userId);
}