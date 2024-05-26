using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Takealittle.Api.Common;
using Takealittle.Application.Features.Products.Commands.CreateProduct;
using Takealittle.Application.Features.Products.Commands.CreateProductImage;
using Takealittle.Application.Features.Products.Commands.DeleteProduct;
using Takealittle.Application.Features.Products.Commands.UpdateProduct;
using Takealittle.Application.Features.Products.Queries.GetAllProducts;
using Takealittle.Application.Features.Products.Queries.GetProduct;
using Takealittle.Application.Wrappers;

namespace Takealittle.Api.Controllers;

[Authorize]
public class ProductController : BaseApiController
{
    private static IWebHostEnvironment _webHostEnvironment;
    
    public ProductController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    /// <summary>
    /// Gets all products
    /// </summary>
    /// <param name="filter"></param>
    /// <returns>A list of all products</returns>
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllProducts([FromQuery] RequestParameter filter)
    {
        var request = new GetAllProductsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber };
        return Ok(await Mediator.Send(request));
    }
    
    /// <summary>
    /// Get a single product by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product info</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        return Ok(await Mediator.Send(new GetProductQuery { Id = id }));
    }
    
    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="command"></param>
    /// <returns>The newly created product</returns>
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    /// <summary>
    /// Update the product with the given id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns>The updated product</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }
    
    /// <summary>
    /// Deletes the product with the given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The id of the product</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return Ok(await Mediator.Send(new DeleteProductCommand { Id = id }));
    }
    
    /// <summary>
    /// Upload an image for a product
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadFile([FromForm] UploadFile file)
    {
        if (file.Files.Length > 0)
        {
            if(file.Files.ContentType != "image/jpeg" && file.Files.ContentType != "image/png")
            {
                return BadRequest("File format not supported");
            }
            
            try
            {
                if(!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                }
                
                var fileExtension = file.Files.FileName.Substring(file.Files.FileName.LastIndexOf(".", StringComparison.Ordinal));
                var fileName = Guid.NewGuid() + fileExtension;
                using(FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + fileName))
                {
                    file.Files.CopyTo(fileStream);
                    fileStream.Flush();
                    
                    var command = new CreateProductImageCommand
                    {
                        FileName = fileName,
                        Description = file.Description,
                        ProductId = file.ProductId
                    };
                    return Ok(await Mediator.Send(command));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return BadRequest();
    }
}