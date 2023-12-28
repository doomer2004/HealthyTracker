using HealthyTracker.Common.Models.DTOs;
using HealthyTracker.Common.Models.DTOs.Product;

namespace HealthyTracker.BLL.Services.ProductService.Interfaces;

public interface IProductService
{
    Task<List<ProductDTO>> GetByNameAsync(string name, PaginationDTO pagination);
}