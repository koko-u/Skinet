using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;

namespace Skinet.Infrastructure.Repositories;

public class ProductsRepository(StoreDbContext dbContext) : IProductsRepository
{
    public async Task<Product?> GetProductByIdAsync(int productId) =>
        await dbContext.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .SingleOrDefaultAsync(product1 => product1.Id == productId);

    public async Task<IReadOnlyList<Product>> GetAllProductsAsync() =>
        await dbContext.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();
}