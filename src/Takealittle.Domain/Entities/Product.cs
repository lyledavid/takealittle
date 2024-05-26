using Takealittle.Domain.Common;

namespace Takealittle.Domain.Entities;

public class Product : AuditableBaseEntity
{
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    
    public List<ProductImage> ProductImages { get; set; }
}