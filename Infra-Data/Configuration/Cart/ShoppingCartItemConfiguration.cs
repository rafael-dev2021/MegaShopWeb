using Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Cart;

public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ShoppingCartId).HasMaxLength(200);

        builder.HasOne(x => x.Product)
            .WithMany()  
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
