using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(60).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(10000).IsRequired();
        builder.Property(x => x.Images).HasMaxLength(800).IsRequired();
        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        builder.Property(x => x.RowVersion).IsRowVersion();

        builder
             .OwnsOne(x => x.ProductDataObjectValue, productData =>
             {
                 productData.Property(pd => pd.ReleaseMonth)
                            .HasMaxLength(12)
                            .IsRequired();

                 productData.Property(pd => pd.ReleaseYear)
                            .HasMaxLength(4)
                            .IsRequired();
             });


        builder
             .OwnsOne(x => x.ProductWarrantyObjectValue, warranty =>
             {
                 warranty.Property(w => w.WarrantyLength)
                         .HasMaxLength(30)
                         .IsRequired();

                 warranty.Property(w => w.WarrantyInformation)
                         .HasMaxLength(30)
                         .IsRequired();
             });


        builder
             .OwnsOne(x => x.ProductSpecificationsObjectValue, specs =>
             {
                 specs.Property(s => s.ProductModel)
                      .HasMaxLength(50)
                      .IsRequired();

                 specs.Property(s => s.ProductBrand)
                      .HasMaxLength(20)
                      .IsRequired();

                 specs.Property(s => s.ProductLine)
                      .HasMaxLength(20)
                      .IsRequired();

                 specs.Property(s => s.ProductWeight)
                      .HasMaxLength(20)
                      .IsRequired();

                 specs.Property(s => s.ProductType)
                      .HasMaxLength(20)
                      .IsRequired();
             });


        builder
             .OwnsOne(x => x.ProductPriceObjectValue, pp =>
             {
                 pp.Property(p => p.Price)
                     .HasPrecision(18, 2)
                     .IsRequired();

                 pp.Property(p => p.HistoryPrice)
                     .HasPrecision(18, 2);
             });
    }
}
