using Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Payments;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.CreditCardNumber).HasMaxLength(19).IsRequired();
        builder.Property(x=>x.CreditCardHolderName).HasMaxLength(50).IsRequired();
        builder.Property(x=>x.CreditCardExpirationDate).HasMaxLength(5).IsRequired();
        builder.Property(x=>x.CreditCardCVV).HasMaxLength(4).IsRequired();
    }
}
