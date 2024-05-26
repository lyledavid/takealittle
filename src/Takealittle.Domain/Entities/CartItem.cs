using System.ComponentModel.DataAnnotations.Schema;

namespace Takealittle.Domain.Entities;

public class CartItem
{
    public int Id { get; set; }
    
    public int CartId { get; set; }
    [ForeignKey(nameof(CartId))]
    public virtual Cart Cart { get; set; }
    
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
}