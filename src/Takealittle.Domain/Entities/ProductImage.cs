using System.ComponentModel.DataAnnotations.Schema;
using Takealittle.Domain.Common;

namespace Takealittle.Domain.Entities;

public class ProductImage : AuditableBaseEntity
{
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
}