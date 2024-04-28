using AutoMapper;
using Skinet.Api.Dtos;
using Skinet.Core.Entities;

namespace Skinet.Api.Profiles;

public class ProductTypeProfile : Profile
{
    public ProductTypeProfile()
    {
        CreateMap<Product, ProductTypeDto.P>();
        CreateMap<ProductType, ProductTypeDto>();
    }
}