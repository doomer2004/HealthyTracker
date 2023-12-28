using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.Product;
using LanguageExt;

namespace HealthyTracker.BLL.Services.ProductService.Interfaces;

public interface IProductActualService
{
    Task<Either<ErrorDTO, ProductActualDTO>> UpdateAsync(Guid userId, ProductActualDTO dto);
    Task<Option<ErrorDTO>> DeleteAsync(Guid userId, Guid productId);
}