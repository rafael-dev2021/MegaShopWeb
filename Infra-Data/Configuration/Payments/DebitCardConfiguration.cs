//using Domain.Entities.Payments;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infra_Data.Configuration.Payments;

//public class DebitCardConfiguration : IEntityTypeConfiguration<DebitCard>
//{
//    public void Configure(EntityTypeBuilder<DebitCard> builder)
//    {
//        builder.HasKey(x => x.Id);
//        builder.Property(x => x.DebitCardNumber).HasMaxLength(19).IsRequired();
//        builder.Property(x => x.DebitCardHolderName).HasMaxLength(50).IsRequired();
//        builder.Property(x => x.DebitCardExpirationDate).HasMaxLength(5).IsRequired();
//        builder.Property(x => x.DebitCardCVV).HasMaxLength(4).IsRequired();
//    }
//}
