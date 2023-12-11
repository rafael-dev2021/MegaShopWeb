using Domain.Entities.Payments.CreditCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Payments.CreditCards
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.Property(x => x.CardNumber).HasMaxLength(19).IsRequired();
            builder.Property(x => x.CardHolderName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ExpirationDate).HasMaxLength(5).IsRequired();
            builder.Property(x => x.CVV).HasMaxLength(4).IsRequired();
        }
    }
}
