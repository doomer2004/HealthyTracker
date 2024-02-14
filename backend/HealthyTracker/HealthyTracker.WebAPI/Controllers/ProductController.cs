using HealthyTracker.BLL.Services.ProductService.Interfaces;
using HealthyTracker.BLL.Services.ProductService.Services;
using HealthyTracker.Common.Models.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyTracker.WebAPI.Controllers;


[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        try
        {
            await _productService.AddProduct(request.Name, request.Volume, request.MealId);
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