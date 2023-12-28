using AutoMapper;
using HealthyTracker.BLL.Services.ProductService.Interfaces;
using HealthyTracker.Common.Models.DTOs;
using HealthyTracker.Common.Models.DTOs.Product;
using HealthyTracker.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.BLL.Services.ProductService.Services;

public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(ProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductDTO>> GetByNameAsync(string name, PaginationDTO pagination)
    {
        var products = await _productRepository.Table.FromSqlInterpolated(
                $"""
                     SELECT P.Name
                     FROM Product P
                     LEFT JOIN FundraisingTag FT ON T.Name = FT.TagsName
                     WHERE T.Name LIKE {($"%{name}%")}
                     GROUP BY T.Name
                     ORDER BY COUNT(FT.TagsName) DESC
                     OFFSET {pagination.PageSize * (pagination.Page - 1)} ROWS
                     FETCH NEXT {pagination.PageSize} ROWS ONLY
                 """)
        .ToListAsync();

        return _mapper.Map<List<ProductDTO>>(products);
    }
}