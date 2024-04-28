using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Skinet.Core.Entities;

[Table("product_types")]
public class ProductType
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("name")] 
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Product> Products { get; set; } = [];
}