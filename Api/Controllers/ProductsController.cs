using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Infrastructure.Data;

namespace Skinet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(StoreDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await dbContext.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<string>> GetSingleProduct(int id)
    {
        var product = await dbContext.Products.SingleOrDefaultAsync(product => product.Id == id);
        if (product is null)
        {
            return NotFound($"The product of id {id} is not found");
        }

        return Ok(product);
    }
}