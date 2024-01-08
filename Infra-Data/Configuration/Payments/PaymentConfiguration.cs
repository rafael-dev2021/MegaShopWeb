using Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Payments;

public class PaymentConsfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CardNumber).HasMaxLength(19).IsRequired();
        builder.Property(x => x.CardHolderName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.ExpirationDate).HasMaxLength(5).IsRequired();
        builder.Property(x => x.SecurityCode).HasMaxLength(4).IsRequired();
        //builder.Property(x => x.Amount).HasPrecision(18, 2);
    }
}
