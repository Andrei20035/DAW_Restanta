namespace DAW_Restanta.Models;
using Microsoft.EntityFrameworkCore;

public class OrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
    {
        return await _context.Orders.Where(o => o.UserID == userId).ToListAsync();
    }

    public async Task<Order> PlaceOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
}
