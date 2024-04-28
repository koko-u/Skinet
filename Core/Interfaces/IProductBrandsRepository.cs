using Skinet.Core.Entities;

namespace Skinet.Core.Interfaces;

public interface IProductBrandsRepository
{
    Task<ProductBrand?> GetProductBrandByIdAsync(int productBrandId);
    Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync();
}