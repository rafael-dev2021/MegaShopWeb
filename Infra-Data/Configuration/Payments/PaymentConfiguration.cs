using Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Payments;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Amount).HasPrecision(18, 2);
        builder.Property(u => u.SSN).HasMaxLength(15);

        builder.OwnsOne(x => x.PaymentMethodObjectValue, paymentMethod =>
        {
            paymentMethod.OwnsOne(pm => pm.PaymentStatusObjectValue, paymentStatus =>
            {
                paymentStatus.Property(ps => ps.PaymentStatus).IsRequired();
            });

            paymentMethod.Property(pm => pm.PaymentMethod).IsRequired();
        });
    }
}
