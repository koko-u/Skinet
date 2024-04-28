using Skinet.Core.Entities;

namespace Skinet.Api.Dtos;

public class ProductBrandDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public IReadOnlyList<P> Products { get; set; } = [];


    public class P
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
    }    
}