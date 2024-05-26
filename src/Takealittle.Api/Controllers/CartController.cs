using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takealittle.Application.Features.Cart.Commands.AddCartItem;
using Takealittle.Application.Features.Cart.Commands.CreateCart;
using Takealittle.Application.Features.Cart.Commands.DeleteCart;
using Takealittle.Application.Features.Cart.Commands.RemoveCartItem;
using Takealittle.Application.Features.Cart.Queries.GetActiveCart;

namespace Takealittle.Api.Controllers;

[Authorize]
public class CartController : BaseApiController
{
    /// <summary>
    /// Get the active cart for the current user
    /// </summary>
    /// <returns>A cart object</returns>
    [HttpGet]
    public async Task<IActionResult> GetActiveCart()
    {
        var request = new GetActiveCartQuery();
        return Ok(await Mediator.Send(request));
    }
    
    /// <summary>
    /// Creates a new cart for the current user
    /// </summary>
    /// <param name="command"></param>
    /// <returns>The id of the newly created cart</returns>
    [HttpPost]
    public async Task<IActionResult> CreateCart(CreateCartCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    /// <summary>
    /// Delete a cart by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The id of the cart</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart(int id)
    {
        return Ok(await Mediator.Send(new DeleteCartCommand { Id = id }));
    }
    
    /// <summary>
    /// Add an item to the active cart for the current user
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("add-cart-item")]
    public async Task<IActionResult> AddCartItem(AddCartItemCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    /// <summary>
    /// Remove an item from the active cart for the current user
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("remove-cart-item/{id}")]
    public async Task<IActionResult> RemoveCartItem(int id)
    {
        return Ok(await Mediator.Send(new RemoveCartItemCommand { Id = id }));
    }
}