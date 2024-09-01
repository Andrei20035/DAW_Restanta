using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DAW_Restanta.Models;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<OrderDetails> OrderDetails { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}
