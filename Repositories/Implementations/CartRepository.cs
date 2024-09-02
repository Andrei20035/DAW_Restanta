using DAW_Restanta.Models;
using DAW_Restanta.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAW_Restanta.Repositories.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsAsync()
        {
            return await _context.ShoppingCarts.ToListAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByIdAsync(int cartId)
        {
            return await _context.ShoppingCarts.FindAsync(cartId);
        }

        public async Task AddShoppingCartAsync(ShoppingCart shoppingCart)
        {
            await _context.ShoppingCarts.AddAsync(shoppingCart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Update(shoppingCart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShoppingCartAsync(int cartId)
        {
            var shoppingCart = await _context.ShoppingCarts.FindAsync(cartId);
            if (shoppingCart != null)
            {
                _context.ShoppingCarts.Remove(shoppingCart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
