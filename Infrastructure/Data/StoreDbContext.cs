using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;

namespace Skinet.Infrastructure.Data;

public class StoreDbContext(DbContextOptions<StoreDbContext> opt) : DbContext(opt)
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();
    
    public DbSet<ProductType> ProductTypes => Set<ProductType>();
}