using Domain.Entities;
using Domain.Entities.Payments;
using Domain.Entities.Payments.CreditCards;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Tshirts;
using Domain.Entities.Products.Technology.Games;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Entities.Reviews;
using Infra_Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<UserGeneric>(options)
    {
        //Entities
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //Entities/Payments
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        //Fashion
        public DbSet<Tshirt> Tshirts { get; set; }
        public DbSet<Shoes> Shoes { get; set; }

        //Technology
        public DbSet<Game> Games { get; set; }
        public DbSet<Smartphone> Smartphones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }


    }
}
