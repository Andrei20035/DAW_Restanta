namespace DAW_Restanta.Services;
using DAW_Restanta.Models;
using Microsoft.EntityFrameworkCore;

public class CartService
{
    private readonly ApplicationDbContext _context;

    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CartItem>> GetCartItems(int cartId)
    {
        return await _context.CartItems.Where(c => c.CartID == cartId).ToListAsync();
    }

    public async Task<CartItem> AddToCart(CartItem cartItem)
    {
        _context.CartItems.Add(cartItem);
        await _context.SaveChangesAsync();
        return cartItem;
    }

    public async Task<bool> RemoveFromCart(int id)
    {
        var cartItem = await _context.CartItems.FindAsync(id);
        if (cartItem == null) return false;
        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClearCart(int cartId)
    {
        var items = await _context.CartItems.Where(c => c.CartID == cartId).ToListAsync();
        if (items.Count == 0) return false;
        _context.CartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
        return true;
    }
}
