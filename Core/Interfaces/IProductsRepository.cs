using Skinet.Core.Entities;

namespace Skinet.Core.Interfaces;

public interface IProductsRepository
{
    Task<Product?> GetProductByIdAsync(int productId);
    Task<IReadOnlyList<Product>> GetAllProductsAsync();
}