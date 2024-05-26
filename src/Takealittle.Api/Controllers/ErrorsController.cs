using Microsoft.AspNetCore.Mvc;

namespace Takealittle.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    [HttpGet]
    public IActionResult Error()
    {
        return Problem();
    }
}