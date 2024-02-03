using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Orders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.TotalOrder)
            .HasPrecision(18, 2);

        builder
            .OwnsOne(x => x.DeliveryAddress, order =>
            {
                order.Property(o => o.ZipCode)
                        .HasMaxLength(11)
                        .IsRequired();

                order.Property(o => o.Address)
                        .HasMaxLength(60)
                        .IsRequired();

                order.Property(o => o.Complement)
                        .HasMaxLength(60)
                        .IsRequired();

                order.Property(o => o.State)
                        .HasMaxLength(30)
                        .IsRequired();

                order.Property(o => o.City)
                        .HasMaxLength(30)
                        .IsRequired();

                order.Property(o => o.Neighborhood)
                        .HasMaxLength(30)
                        .IsRequired();

                order.Property(o => o.Country)
                       .HasMaxLength(30)
                       .IsRequired();
            });

        builder
           .OwnsOne(x => x.UserDelivery, user =>
           {
               user.Property(u => u.FirstName)
               .HasMaxLength(15).
               IsRequired();

               user.Property(u => u.LastName)
               .HasMaxLength(15).
               IsRequired();

               user.Property(u => u.Email)
               .HasMaxLength(50).
               IsRequired();

               user.Property(u => u.Phone)
               .HasMaxLength(16).
               IsRequired();

               user.Property(u => u.SSN)
               .HasMaxLength(15).
               IsRequired();
           });
    }
}
