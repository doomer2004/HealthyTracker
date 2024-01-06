using HealthyTracker.Common.Models.DTOs;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.Common.Models.Utility;
using LanguageExt;

namespace HealthyTracker.BLL.Services.ProductService.Interfaces;

public interface IProductService
{
    Task<Option<ErrorModel>> AddProduct(string name, int volume, Guid mealId); 
    
    Task<Option<ErrorModel>> UpdateProduct(Guid productId, int volume);
    
    Task<Option<ErrorModel>> DeleteProduct(Guid productId);

}