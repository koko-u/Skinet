using Skinet.Core.Entities;

namespace Skinet.Core.Interfaces;

public interface IProductTypesRepository
{
    Task<ProductType?> GetProductTypeByIdAsync(int productTypeId);
    Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
}