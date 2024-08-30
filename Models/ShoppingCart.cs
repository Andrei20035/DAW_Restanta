namespace DAW_Restanta.Models;

public class ShoppingCart
{
    public int CartID { get; set; }
    public int UserID { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}
