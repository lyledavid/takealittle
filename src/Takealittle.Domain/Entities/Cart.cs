namespace Takealittle.Domain.Entities;

public class Cart
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public bool IsProcessed { get; set; }
    public string User { get; set; }
}