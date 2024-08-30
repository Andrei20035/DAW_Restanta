using System;
using System.Collections.Generic;

namespace DAW_Restanta.Models;

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
}
