﻿using System;
using System.Collections.Generic;

namespace DAW_Restanta.Models;

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Role { get; set; } = "User"; // Adaugă acest câmp pentru roluri

    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}

