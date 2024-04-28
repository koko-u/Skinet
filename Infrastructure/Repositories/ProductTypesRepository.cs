using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;

namespace Skinet.Infrastructure.Repositories;

public class ProductTypesRepository(StoreDbContext dbContext) : IProductTypesRepository 
{
    public async Task<ProductType?> GetProductTypeByIdAsync(int productTypeId) =>
        await dbContext.ProductTypes
            .Include(t => t.Products)
            .SingleOrDefaultAsync(productType => productType.Id == productTypeId);

    public async Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync() =>
        await dbContext.ProductTypes
            .Include(t => t.Products)
            .ToListAsync();
}

