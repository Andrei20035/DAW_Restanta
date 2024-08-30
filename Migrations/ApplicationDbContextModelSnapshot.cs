﻿
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAW_Restanta.Migrations;

[DbContext(typeof(ApplicationDbContext))]
partial class ApplicationDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.8")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("Proiect_DAW2.Models.CartItem", b =>
            {
                b.Property<int>("CartItemID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemID"));

                b.Property<int>("CartID")
                    .HasColumnType("int");

                b.Property<int>("ProductID")
                    .HasColumnType("int");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.HasKey("CartItemID");

                b.HasIndex("CartID");

                b.HasIndex("ProductID");

                b.ToTable("CartItems", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Category", b =>
            {
                b.Property<int>("CategoryID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.HasKey("CategoryID");

                b.ToTable("Categories", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Order", b =>
            {
                b.Property<int>("OrderID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                b.Property<DateTime>("OrderDate")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.Property<decimal>("TotalAmount")
                    .HasColumnType("DECIMAL(10, 2)");

                b.Property<int>("UserID")
                    .HasColumnType("int");

                b.HasKey("OrderID");

                b.HasIndex("UserID");

                b.ToTable("Orders", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.OrderDetails", b =>
            {
                b.Property<int>("OrderDetailID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailID"));

                b.Property<int>("OrderID")
                    .HasColumnType("int");

                b.Property<decimal>("Price")
                    .HasColumnType("DECIMAL(10, 2)");

                b.Property<int>("ProductID")
                    .HasColumnType("int");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.HasKey("OrderDetailID");

                b.HasIndex("OrderID");

                b.HasIndex("ProductID");

                b.ToTable("OrderDetails", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Product", b =>
            {
                b.Property<int>("ProductID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                b.Property<DateTime>("CreatedAt")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<byte[]>("Image")
                    .IsRequired()
                    .HasColumnType("VARBINARY(MAX)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<decimal>("Price")
                    .HasColumnType("DECIMAL(10, 2)");

                b.Property<int>("Stock")
                    .HasColumnType("int");

                b.HasKey("ProductID");

                b.ToTable("Products", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.ProductCategory", b =>
            {
                b.Property<int>("ProductID")
                    .HasColumnType("int");

                b.Property<int>("CategoryID")
                    .HasColumnType("int");

                b.HasKey("ProductID", "CategoryID");

                b.HasIndex("CategoryID");

                b.ToTable("ProductCategories");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Review", b =>
            {
                b.Property<int>("ReviewID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                b.Property<string>("Comment")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<DateTime>("CreatedAt")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.Property<int>("ProductID")
                    .HasColumnType("int");

                b.Property<int>("Rating")
                    .HasColumnType("int");

                b.Property<int>("UserID")
                    .HasColumnType("int");

                b.HasKey("ReviewID");

                b.HasIndex("ProductID");

                b.HasIndex("UserID");

                b.ToTable("Reviews", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.ShippingDetails", b =>
            {
                b.Property<int>("ShippingID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShippingID"));

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnType("nvarchar(200)");

                b.Property<string>("City")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Country")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<int>("OrderID")
                    .HasColumnType("int");

                b.Property<string>("PostalCode")
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar(20)");

                b.Property<DateTime>("ShippingDate")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.HasKey("ShippingID");

                b.HasIndex("OrderID")
                    .IsUnique();

                b.ToTable("ShippingDetails", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.ShoppingCart", b =>
            {
                b.Property<int>("CartID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartID"));

                b.Property<DateTime>("CreatedAt")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.Property<int>("UserID")
                    .HasColumnType("int");

                b.HasKey("CartID");

                b.HasIndex("UserID");

                b.ToTable("ShoppingCart", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.User", b =>
            {
                b.Property<int>("UserID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnType("nvarchar(200)");

                b.Property<DateTime>("CreatedAt")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("PasswordHash")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<string>("Username")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.HasKey("UserID");

                b.ToTable("Users", (string)null);
            });

        modelBuilder.Entity("Proiect_DAW2.Models.CartItem", b =>
            {
                b.HasOne("Proiect_DAW2.Models.ShoppingCart", "ShoppingCart")
                    .WithMany("CartItems")
                    .HasForeignKey("CartID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Proiect_DAW2.Models.Product", "Product")
                    .WithMany("CartItems")
                    .HasForeignKey("ProductID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Product");

                b.Navigation("ShoppingCart");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Order", b =>
            {
                b.HasOne("Proiect_DAW2.Models.User", "User")
                    .WithMany("Orders")
                    .HasForeignKey("UserID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.OrderDetails", b =>
            {
                b.HasOne("Proiect_DAW2.Models.Order", "Order")
                    .WithMany("OrderDetails")
                    .HasForeignKey("OrderID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Proiect_DAW2.Models.Product", "Product")
                    .WithMany("OrderDetails")
                    .HasForeignKey("ProductID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Order");

                b.Navigation("Product");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.ProductCategory", b =>
            {
                b.HasOne("Proiect_DAW2.Models.Category", "Category")
                    .WithMany("ProductCategories")
                    .HasForeignKey("CategoryID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Proiect_DAW2.Models.Product", "Product")
                    .WithMany("ProductCategories")
                    .HasForeignKey("ProductID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Category");

                b.Navigation("Product");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Review", b =>
            {
                b.HasOne("Proiect_DAW2.Models.Product", "Product")
                    .WithMany("Reviews")
                    .HasForeignKey("ProductID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Proiect_DAW2.Models.User", "User")
                    .WithMany("Reviews")
                    .HasForeignKey("UserID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Product");

                b.Navigation("User");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.ShippingDetails", b =>
            {
                b.HasOne("Proiect_DAW2.Models.Order", "Order")
                    .WithOne("ShippingDetails")
                    .HasForeignKey("Proiect_DAW2.Models.ShippingDetails", "OrderID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Order");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.ShoppingCart", b =>
            {
                b.HasOne("Proiect_DAW2.Models.User", "User")
                    .WithMany("ShoppingCarts")
                    .HasForeignKey("UserID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Category", b =>
            {
                b.Navigation("ProductCategories");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Order", b =>
            {
                b.Navigation("OrderDetails");

                b.Navigation("ShippingDetails")
                    .IsRequired();
            });

        modelBuilder.Entity("Proiect_DAW2.Models.Product", b =>
            {
                b.Navigation("CartItems");

                b.Navigation("OrderDetails");

                b.Navigation("ProductCategories");

                b.Navigation("Reviews");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.ShoppingCart", b =>
            {
                b.Navigation("CartItems");
            });

        modelBuilder.Entity("Proiect_DAW2.Models.User", b =>
            {
                b.Navigation("Orders");

                b.Navigation("Reviews");

                b.Navigation("ShoppingCarts");
            });
#pragma warning restore 612, 618
    }
}
