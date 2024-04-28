using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Api.Dtos;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;

namespace Skinet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(
    IProductsRepository productsRepository,
    IProductBrandsRepository brandsRepository,
    IProductTypesRepository typesRepository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        var products = await productsRepository.GetAllProductsAsync();
        return Ok(mapper.Map<IReadOnlyList<Product>, List<ProductDto>>(products));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetSingleProduct([FromRoute(Name = "id")] int productId)
    {
        var product = await productsRepository.GetProductByIdAsync(productId);
        if (product is null)
        {
            return NotFound($"The product of id {productId} is not found");
        }

        return Ok(mapper.Map<Product, ProductDto>(product));
    }

    [HttpGet]
    [Route("brands")]
    public async Task<ActionResult<List<ProductBrandDto>>> GetAllProductBrands()
    {
        var brands = await brandsRepository.GetAllProductBrandsAsync();
        return Ok(mapper.Map<IReadOnlyList<ProductBrand>, List<ProductBrandDto>>(brands));
    }

    [HttpGet]
    [Route("types")]
    public async Task<ActionResult<List<ProductType>>> GetAllProductTypes()
    {
        var types = await typesRepository.GetAllProductTypesAsync();
        return Ok(mapper.Map<IReadOnlyList<ProductType>, List<ProductTypeDto>>(types));
    }
}