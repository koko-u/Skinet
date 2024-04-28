using AutoMapper;
using Skinet.Api.Dtos;
using Skinet.Core.Entities;

namespace Skinet.Api.Profiles;

public class ProductBrandProfile : Profile
{
    public ProductBrandProfile()
    {
        CreateMap<Product, ProductBrandDto.P>();
        CreateMap<ProductBrand, ProductBrandDto>();
    }
}