using Microsoft.AspNetCore.Mvc;
namespace DAW_Restanta.Models;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("{cartId}")]
    public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(int cartId)
    {
        var items = await _cartService.GetCartItems(cartId);
        return Ok(items);
    }

    [HttpPost]
    public async Task<ActionResult<CartItem>> AddToCart(CartItem cartItem)
    {
        var newItem = await _cartService.AddToCart(cartItem);
        return CreatedAtAction(nameof(GetCartItems), new { cartId = newItem.CartID }, newItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFromCart(int id)
    {
        var result = await _cartService.RemoveFromCart(id);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpPost("clear/{cartId}")]
    public async Task<IActionResult> ClearCart(int cartId)
    {
        var result = await _cartService.ClearCart(cartId);
        if (!result) return NotFound();
        return NoContent();
    }
}
