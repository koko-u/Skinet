using AutoMapper;
using Skinet.Api.Dtos;
using Skinet.Core.Entities;

namespace Skinet.Api.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
            .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name));
    }
}