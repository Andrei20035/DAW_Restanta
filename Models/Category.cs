﻿namespace DAW_Restanta.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string Name { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; }
}
