using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;

namespace Skinet.Infrastructure.Data;

public static class StoreDbContextSeed
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
    private static string AssemblyName => Assembly.GetName().Name!;

    public static async Task SeedAsync(StoreDbContext dbContext)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        if (!await dbContext.ProductBrands.AnyAsync())
        {
            var brands = await GetBrandsFromResource();
            await dbContext.ProductBrands.AddRangeAsync(brands);
            await dbContext.SaveChangesAsync();
        };

        if (!await dbContext.ProductTypes.AnyAsync())
        {
            var types = await GetTypesFromResource();
            await dbContext.ProductTypes.AddRangeAsync(types);
            await dbContext.SaveChangesAsync();
        }

        if (!await dbContext.Products.AnyAsync())
        {
            var products = await GetProductsFromResource();
            foreach (var product in products)
            {
                var productBrand = await dbContext.ProductBrands.FirstAsync(brand => brand.Name == product.ProductBrand.Name);
                product.ProductBrand = productBrand;
                var productType = await dbContext.ProductTypes.FirstAsync(type_ => type_.Name == product.ProductType.Name);
                product.ProductType = productType;
            }
            await dbContext.Products.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();
        }

        await transaction.CommitAsync();
    }

    private static async Task<List<ProductBrand>> GetBrandsFromResource()
    {
        await using var brandsStream = Assembly.GetManifestResourceStream($"{AssemblyName}.Seeds.brands.json");
        if (brandsStream is null)
        {
            return [];
        }

        var brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(brandsStream);
        return brands ?? [];
    }

    private static async Task<List<ProductType>> GetTypesFromResource()
    {
        await using var typesStream = Assembly.GetManifestResourceStream($"{AssemblyName}.Seeds.types.json");
        if (typesStream is null)
        {
            return [];
        }

        var types = await JsonSerializer.DeserializeAsync<List<ProductType>>(typesStream);
        return types ?? [];
    }

    private static async Task<List<Product>> GetProductsFromResource()
    {
        await using var productsStream = Assembly.GetManifestResourceStream($"{AssemblyName}.Seeds.products.json");
        if (productsStream is null)
        {
            return [];
        }

        var products = await JsonSerializer.DeserializeAsync<List<Product>>(productsStream);
        return products ?? [];
    }
}