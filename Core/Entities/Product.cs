using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Skinet.Core.Entities;

[Table("products")]
public class Product
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("name")] 
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string Description { get; set; } = string.Empty;
    
    [Column("price")]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [Column("picture_url")]
    [MaxLength(255)]
    public string PictureUrl { get; set; } = string.Empty;
    
    [ForeignKey(nameof(ProductTypeId))]
    public required ProductType ProductType { get; set; }
    
    [Column("product_type_id")]
    public int ProductTypeId { get; set; }
    
    [ForeignKey(nameof(ProductBrandId))]
    public required ProductBrand ProductBrand { get; set; }
    
    [Column("product_brand_id")]
    public int ProductBrandId { get; set; }
}