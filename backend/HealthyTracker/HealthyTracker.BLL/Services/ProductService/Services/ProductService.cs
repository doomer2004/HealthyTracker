using AutoMapper;
using HealthyTracker.BLL.Services.ProductService.Interfaces;
using HealthyTracker.Client.Nutrition;
using HealthyTracker.Client.Nutrition.Models.Requests;
using HealthyTracker.Client.Nutrition.Models.Responses;
using HealthyTracker.Common.Enums;
using HealthyTracker.Common.Models.DTOs;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.Common.Models.Utility;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using HealthyTracker.DAL.Repositories.Interfaces;
using LanguageExt;
using LanguageExt.ClassInstances;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HealthyTracker.BLL.Services.ProductService.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly INutritionsClient _nutritionsClient;
    private readonly IMealRepository _mealRepository;
    private readonly ILogger _logger;

    public ProductService(IProductRepository productRepository, IMapper mapper,
        INutritionsClient nutritionsClient, IMealRepository mealRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _nutritionsClient = nutritionsClient;
        _mealRepository = mealRepository;
        _logger = logger;
    }
    public async Task<Option<ErrorModel>> AddProduct(string name, int volume, Guid mealId)
    {
        try
        {
            var request = await _nutritionsClient.GetNutritionsByNameAsync
                (new GetNutritionByNameRequest {Query = name});
            var products = ParseProducts(request);
            var product = await ProductByParams(products, volume);
            var productResponse = _mapper.Map<Product>(product);
            _mealRepository.Table.First(meal => meal.Id == mealId).Products.Add(productResponse);
            await _mealRepository.SaveChangesAsync();
            return Option<ErrorModel>.None;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new ErrorModel(e.Message);
        }
    }

    public async Task<Option<ErrorModel>> UpdateProduct(Guid productId, int volume)
    {
        try
        {
            var product = _productRepository.Table.Where(p => p.Id == productId);
            ;
            var updatedProduct = await ProductByParams(product.ToList(), volume);
            var productResponse = _mapper.Map<Product>(product);
            await _productRepository.Update(productResponse);
            return Option<ErrorModel>.None;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new ErrorModel(e.Message);
        }
    }

    public async Task<Option<ErrorModel>> DeleteProduct(Guid productId)
    {
        try
        {
            var product = await _productRepository.Table.FirstAsync(p => p.Id == productId);
        
            await _productRepository.Delete(product);
                
            return Option<ErrorModel>.None;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new ErrorModel(e.Message);
        }
    }

    private List<Product> ParseProducts(GetNutritionByNameResponse response)
    {
        if (response?.Foods != null && response.Foods.Any())
        {
            return response.Foods.Select(food => new Product
            {
                ProductName = food.FoodName,
                Volume = (int) food.ServingWeightGrams,
                Calories = Convert.ToSingle(food.FullNutrients.First(nutrient => nutrient.AttrId == 208).Value),
                Protein = Convert.ToSingle(food.FullNutrients.First(nutrient => nutrient.AttrId == 203).Value),
                Fat = Convert.ToSingle(food.FullNutrients.First(nutrient => nutrient.AttrId == 204).Value),
                Carbs = Convert.ToSingle(food.FullNutrients.First(nutrient => nutrient.AttrId == 205).Value),
                Salt = Convert.ToSingle(food.FullNutrients.First(nutrient => nutrient.AttrId == 307).Value),
                Caffeine = Convert.ToSingle(food.FullNutrients.First(nutrient => nutrient.AttrId == 262).Value),
                Water = Convert.ToSingle(food.FullNutrients.First(nutrient => nutrient.AttrId == 255).Value),
            }).ToList();
        }
        
        return new List<Product>();
    }

    private Task<ProductDTO> ProductByParams(List<Product> products, int volume)
    {
        var product = products.First();

        var productParams = new ProductDTO
        {
            Volume = 1,
            Calories = (product.Calories / product.Volume) + (product.Calories % product.Volume),
            Protein = (product.Protein / product.Volume) + (product.Protein % product.Volume),
            Fat = (product.Fat / product.Volume) + (product.Fat % product.Volume),
            Carbs = (product.Carbs / product.Volume) + (product.Carbs % product.Volume),
            Salt = (product.Salt / product.Volume) + (product.Salt % product.Volume),
            Caffeine = (product.Caffeine / product.Volume) + (product.Caffeine % product.Volume),
            Water = (product.Water / product.Volume) + (product.Water % product.Volume)
        };

        var realProduct = new ProductDTO
        {
            Volume = volume,
            Calories = productParams.Calories * volume,
            Protein = productParams.Protein * volume,
            Fat = productParams.Fat * volume,
            Carbs = productParams.Carbs * volume,
            Salt = productParams.Salt * volume,
            Caffeine = productParams.Caffeine * volume,
            Water = productParams.Water * volume
        };
        
        return Task.FromResult(realProduct);
    } 
}

