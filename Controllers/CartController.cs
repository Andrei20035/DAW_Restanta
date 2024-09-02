using DAW_Restanta.Models;
using DAW_Restanta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DAW_Restanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCart>>> GetAllShoppingCarts()
        {
            var shoppingCarts = await _shoppingCartService.GetAllShoppingCartsAsync();
            return Ok(shoppingCarts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCartById(int id)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartByIdAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return Ok(shoppingCart);
        }

        [HttpPost]
        public async Task<ActionResult> AddShoppingCart(ShoppingCart shoppingCart)
        {
            await _shoppingCartService.AddShoppingCartAsync(shoppingCart);
            return CreatedAtAction(nameof(GetShoppingCartById), new { id = shoppingCart.CartID }, shoppingCart);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateShoppingCart(int id, ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.CartID)
            {
                return BadRequest();
            }
            await _shoppingCartService.UpdateShoppingCartAsync(shoppingCart);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShoppingCart(int id)
        {
            await _shoppingCartService.DeleteShoppingCartAsync(id);
            return NoContent();
        }
    }
}
