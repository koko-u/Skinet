using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;

namespace Skinet.Infrastructure.Repositories;

public class ProductBrandsRepository(StoreDbContext dbContext) : IProductBrandsRepository
{
    public async Task<ProductBrand?> GetProductBrandByIdAsync(int productBrandId) =>
        await dbContext.ProductBrands
            .Include(b => b.Products)
            .SingleOrDefaultAsync(productBrand => productBrand.Id == productBrandId);

    public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync() =>
        await dbContext.ProductBrands
            .Include(b => b.Products)
            .ToListAsync();
}