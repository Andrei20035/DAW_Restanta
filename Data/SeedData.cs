using DAW_Restanta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DAW_Restanta.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Seeding database...");

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Products.Any())
                {
                    logger.LogInformation("Database already seeded.");
                    return;   
                }

                var products = new List<Product>
                {
                    new Product { Name = "Iphone 15 Pro Max", Description = "Description 1", Price = 6599, Stock = 400, CreatedAt = DateTime.Now, Image = "images/15promax.avif"},
                    new Product { Name = "Samsung A55", Description = "Description 2", Price = 1779, Stock = 400, CreatedAt = DateTime.Now, Image = "images/a55.avif" },
                    new Product { Name = "Frigider", Description = "Description 3", Price = 30.99m, Stock = 300, CreatedAt = DateTime.Now, Image = "images/frigider.avif" },
                    new Product { Name = "Frigider Beko", Description = "Description 4", Price = 40.99m, Stock = 400, CreatedAt = DateTime.Now, Image = "images/frigiderbeko.webp" },
                    new Product { Name = "Macbook Air 13", Description = "Description 5", Price = 50.99m, Stock = 500, CreatedAt = DateTime.Now, Image = "images/macbook.webp" },
                    new Product { Name = "PlayStation 5", Description = "Description 6", Price = 60.99m, Stock = 600, CreatedAt = DateTime.Now, Image = "images/ps5.webp" },
                    new Product { Name = "Samsung S24", Description = "Description 7", Price = 70.99m, Stock = 700, CreatedAt = DateTime.Now, Image = "images/s24.avif" },
                    new Product { Name = "Televizor 4k UHD", Description = "Description 8", Price = 80.99m, Stock = 800, CreatedAt = DateTime.Now, Image = "images/tv1.jpg" },
                    new Product { Name = "Televizor FHD", Description = "Description 9", Price = 90.99m, Stock = 900, CreatedAt = DateTime.Now, Image = "images/tv2.jpg" },
                    new Product { Name = "XBOX Series X", Description = "Description 10", Price = 100.99m, Stock = 1000, CreatedAt = DateTime.Now, Image = "images/xbox.jpg" }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
                logger.LogInformation("Database seeded successfully.");
            }
        }
    }
}
