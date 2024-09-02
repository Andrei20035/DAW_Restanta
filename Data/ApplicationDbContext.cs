using Microsoft.EntityFrameworkCore;
using DAW_Restanta.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<ShippingDetails> ShippingDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many to many relationship between Product and Category
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductID, pc.CategoryID });

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductID);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryID);

        modelBuilder.Entity<OrderDetails>()
            .HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderID);

        modelBuilder.Entity<OrderDetails>()
            .HasOne(od => od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductID);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductID);

        // One to many relationship between User and Review
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserID);

        // One to many relationship between User and Order
        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.ShoppingCart)
            .WithMany(sc => sc.CartItems)
            .HasForeignKey(ci => ci.CartID);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(ci => ci.ProductID);

        // One to one relationship between Order and ShippingDetails
        modelBuilder.Entity<ShippingDetails>()
            .HasOne(sd => sd.Order)
            .WithOne(o => o.ShippingDetails)
            .HasForeignKey<ShippingDetails>(sd => sd.OrderID);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.UserID);
            entity.Property(e => e.UserID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(e => e.ProductID);
            entity.Property(e => e.ProductID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasColumnType("TEXT");
            entity.Property(e => e.Price).IsRequired().HasColumnType("DECIMAL(10, 2)");
            entity.Property(e => e.Image).HasColumnType("TEXT");
            entity.Property(e => e.Stock).IsRequired();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Orders");
            entity.HasKey(e => e.OrderID);
            entity.Property(e => e.OrderID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.OrderDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.TotalAmount).IsRequired().HasColumnType("DECIMAL(10, 2)");
        });

        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.ToTable("OrderDetails");
            entity.HasKey(e => e.OrderDetailID);
            entity.Property(e => e.OrderDetailID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.Price).IsRequired().HasColumnType("DECIMAL(10, 2)");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");
            entity.HasKey(e => e.CategoryID);
            entity.Property(e => e.CategoryID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviews");
            entity.HasKey(e => e.ReviewID);
            entity.Property(e => e.ReviewID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.Rating).IsRequired();
            entity.Property(e => e.Comment).HasColumnType("TEXT");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.ToTable("ShoppingCart");
            entity.HasKey(e => e.CartID);
            entity.Property(e => e.CartID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.ToTable("CartItems");
            entity.HasKey(e => e.CartItemID);
            entity.Property(e => e.CartItemID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.Quantity).IsRequired();
        });

        modelBuilder.Entity<ShippingDetails>(entity =>
        {
            entity.ToTable("ShippingDetails");
            entity.HasKey(e => e.ShippingID);
            entity.Property(e => e.ShippingID).ValueGeneratedOnAdd(); 
            entity.Property(e => e.Address).IsRequired().HasMaxLength(200);
            entity.Property(e => e.City).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PostalCode).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Country).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ShippingDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}
