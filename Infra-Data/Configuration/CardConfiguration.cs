using Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CardNumber).HasMaxLength(19).IsRequired();
        builder.Property(x => x.CardHolderName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.CardExpirationDate).HasMaxLength(5).IsRequired();
        builder.Property(x => x.CardCVV).HasMaxLength(4).IsRequired();
    }
}
