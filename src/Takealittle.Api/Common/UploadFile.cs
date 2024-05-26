namespace Takealittle.Api.Common;

public class UploadFile
{
    public int ProductId { get; set; }
    public IFormFile Files { get; set; }
    public string Description { get; set; }
}