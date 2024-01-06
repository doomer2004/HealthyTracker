using HealthyTracker.BLL.Services.ProductService.Interfaces;
using HealthyTracker.BLL.Services.ProductService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;


[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(string name, int volume, Guid mealId)
    {
        try
        {
            await _productService.AddProduct(name, volume, mealId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(Guid productId, int volume)
    {
        try
        {
            await _productService.UpdateProduct(productId, volume);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        try
        {
            await _productService.DeleteProduct(productId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}