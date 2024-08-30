namespace DAW_Restanta.Models;


public class Order
{
    public int OrderID { get; set; }
    public int UserID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public User User { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }
    public ShippingDetails ShippingDetails { get; set; }
}
