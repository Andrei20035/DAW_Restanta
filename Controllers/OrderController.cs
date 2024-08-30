using Microsoft.AspNetCore.Mvc;
namespace DAW_Restanta.Models;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int userId)
    {
        var orders = await _orderService.GetOrdersByUserId(userId);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> PlaceOrder(Order order)
    {
        var newOrder = await _orderService.PlaceOrder(order);
        return CreatedAtAction(nameof(GetOrders), new { userId = newOrder.UserID }, newOrder);
    }
}
