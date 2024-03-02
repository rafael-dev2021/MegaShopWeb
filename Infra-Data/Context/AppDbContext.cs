using Domain.Entities;
using Domain.Entities.Cart;
using Domain.Entities.Orders;
using Domain.Entities.Payments;
using Domain.Entities.Products.Fashion.ProductShoes;
using Domain.Entities.Products.Fashion.Tshirts;
using Domain.Entities.Products.Technology.Games;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Entities.Reviews;
using Infra_Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Category> Categories { get; set; } = null;
    public DbSet<Product> Products { get; set; } = null;
    public DbSet<Review> Reviews { get; set; } = null;
    public DbSet<Order> Orders { get; set; } = null;
    public DbSet<Payment> Payments { get; set; } = null;
    public DbSet<Card> Cards { get; set; } = null;
    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null;
    public DbSet<CreditCard> CreditCards { get; set; } = null;
    public DbSet<DebitCard> DebitCards { get; set; } = null;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null;
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null;
    public DbSet<Tshirt> Tshirts { get; set; } = null;
    public DbSet<Shoes> Shoes { get; set; } = null;
    public DbSet<Game> Games { get; set; } = null;
    public DbSet<Smartphone> Smartphones { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
