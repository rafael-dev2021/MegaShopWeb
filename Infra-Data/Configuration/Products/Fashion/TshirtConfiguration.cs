using Domain.Entities.Products.Fashion.Tshirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Fashion;

public class TshirtConfiguration : IEntityTypeConfiguration<Tshirt>
{
    public void Configure(EntityTypeBuilder<Tshirt> builder)
    {
        builder.HasData(
           new Tshirt(
               7,
               "Top Nike Swoosh Woman",
               "The Nike Classic Swoosh Futura medium support women\'s workout top offers long-lasting comfort during training with sweat-wicking fabric and a compression fit.",
               [
                   "https://imgnike-a.akamaihd.net/768x768/002897ID.jpg",
                   "https://imgnike-a.akamaihd.net/768x768/002897IDA1.jpg",
                   "https://imgnike-a.akamaihd.net/768x768/002897IDA4.jpg",
                   "https://imgnike-a.akamaihd.net/768x768/002897IDA5.jpg"
               ],
               5,
               2
               ),
            new Tshirt(
               8,
               "Adicolor classics firebird track jacket",
               "Fresh and full of life, this Adicolor Firebird track jacket celebrates the power and authenticity of adidas\' legendary DNA.",
               [
                   "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a5757a66a549439cbac6afcd002ca57f_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_01_laydown.jpg",
                   "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/3cae025992434e889496afcd002c97ae_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_42_detail.jpg",
                   "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/c6f0e6def4bd4eefa0bfafcd002c7094_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_21_model.jpg",
                   "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a915172e29f24ce4b34bafcd002c78dc_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_23_hover_model.jpg"
               ],
               8,
               2
               ));
        ConfigureSpecificationsVO(builder);
        ConfigurePriceVO(builder);
        ConfigureWarrantyVO(builder);
        ConfigureFlagsVO(builder);
        ConfigureDataVO(builder);
        ConfigureTshirtMainFeaturesOV(builder);
        ConfigureTshirtOtherFeaturesOV(builder);
    }
    private static void ConfigureSpecificationsVO(EntityTypeBuilder<Tshirt> builder)
    {
        builder.OwnsOne(x => x.ProductSpecificationsObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 7,
                    ProductModel = "Nike T-Shirt",
                    ProductBrand = "Nike",
                    ProductLine = "",
                    ProductWeight = "200 g",
                    ProductType = "T-Shirt"
                });
                sa.HasData(new
                {
                    Id = 8,
                    ProductModel = "JACKET Adidas",
                    ProductBrand = "Adidas",
                    ProductLine = "",
                    ProductWeight = "350 g",
                    ProductType = "T-Shirt"
                });
            });
    }
   
    private static void ConfigurePriceVO(EntityTypeBuilder<Tshirt> builder)
    {
        builder.OwnsOne(x => x.ProductPriceObjectValue,
         sa =>
         {
             sa.Property<int>("Id");
             sa.HasKey("Id");
             sa.HasData(new
             {
                 Id = 7,
                 Price = 16.99M,
                 HistoryPrice = 0.0M
             });
             sa.HasData(new
             {
                 Id = 8,
                 Price = 64.99M,
                 HistoryPrice = 80.0M
             });
         });
    }
    private static void ConfigureWarrantyVO(EntityTypeBuilder<Tshirt> builder)
    {
        builder.OwnsOne(x => x.ProductWarrantyObjectValue,
          sa =>
          {
              sa.Property<int>("Id");
              sa.HasKey("Id");
              sa.HasData(new
              {
                  Id = 7,
                  WarrantyLength = "1-year warranty",
                  WarrantyInformation = "15-Day Limited Warranty"
              });
              sa.HasData(new
              {
                  Id = 8,
                  WarrantyLength = "1-year warranty",
                  WarrantyInformation = "15-Day Limited Warranty"
              });
          });
    }
    private static void ConfigureFlagsVO(EntityTypeBuilder<Tshirt> builder)
    {
        builder.OwnsOne(x => x.ProductFlagsObjectValue,
          sa =>
          {
              sa.Property<int>("Id");
              sa.HasKey("Id");
              sa.HasData(new
              {
                  Id = 7,
                  IsDailyOffer = false,
                  IsFavorite = true,
                  IsBestSeller = true
              });
              sa.HasData(new
              {
                  Id = 8,
                  IsDailyOffer = true,
                  IsFavorite = false,
                  IsBestSeller = false
              });
          });
    }
    private static void ConfigureDataVO(EntityTypeBuilder<Tshirt> builder)
    {
        builder.OwnsOne(x => x.ProductDataObjectValue,
           sa =>
           {
               sa.Property<int>("Id");
               sa.HasKey("Id");
               sa.HasData(new
               {
                   Id = 7,
                   ReleaseMonth = "June",
                   ReleaseYear = "2023"
               });
               sa.HasData(new
               {
                   Id = 8,
                   ReleaseMonth = "March",
                   ReleaseYear = "2023"
               });
           });
    }
    private static void ConfigureTshirtMainFeaturesOV(EntityTypeBuilder<Tshirt> builder)
    {
        builder.OwnsOne(x => x.TshirtMainFeaturesObectsValue,
           sa =>
           {
               sa.Property(x => x.Gender)
                .HasMaxLength(10)
                .IsRequired();
               sa.Property(x => x.Age)
                .HasMaxLength(10)
                .IsRequired();
               sa.Property(x => x.TypeOfClothing)
                .HasMaxLength(15)
                .IsRequired();
               sa.Property(x => x.FabricDesign)
                .HasMaxLength(15);
               sa.Property(x => x.Size)
                .HasMaxLength(5)
                .IsRequired();


               sa.Property<int>("Id");
               sa.HasKey("Id");
               sa.HasData(new
               {
                   Id = 7,
                   Gender = "Woman",
                   Age = "Adult",
                   TypeOfClothing = "T-shirt",
                   FabricDesign = "Straight",
                   Size = "S"
               });
               sa.HasData(new
               {
                   Id = 8,
                   Gender = "Woman",
                   Age = "Adult",
                   TypeOfClothing = "T-shirt",
                   FabricDesign = "Straight",
                   Size = "XS"
               });
           });
    }
    private static void ConfigureTshirtOtherFeaturesOV(EntityTypeBuilder<Tshirt> builder)
    {
        builder.OwnsOne(x => x.TshirtOtherFeaturesObectsValue,
           sa =>
           {
               sa.Property(x => x.RecommendedUses)
               .HasMaxLength(15)
               .IsRequired();
               sa.Property(x => x.KindOfFabric)
               .HasMaxLength(10);
               sa.Property(x => x.Composition)
               .HasMaxLength(15);
               sa.Property(x => x.MainMaterial)
               .HasMaxLength(15)
               .IsRequired();
               sa.Property(x => x.SleeveType)
               .HasMaxLength(15);
               sa.Property(x => x.TypeOfCollar)
               .HasMaxLength(15);
               sa.Property(x => x.UnitsPerKit)
               .HasConversion<int>();
               sa.Property(x => x.WithRecycledMaterials)
               .HasConversion<bool>();
               sa.Property(x => x.ItsSporty)
             .HasConversion<bool>();

               sa.Property<int>("Id");
               sa.HasKey("Id");
               sa.HasData(new
               {
                   Id = 7,
                   RecommendedUses = "Casual",
                   KindOfFabric = "Dry",
                   Composition = "Polyester",
                   MainMaterial = "Polyester",
                   SleeveType = "Like",
                   TypeOfCollar = "Round neck",
                   UnitsPerKit = 1,
                   WithRecycledMaterials = false,
                   ItsSporty = false
               });
               sa.HasData(new
               {
                   Id = 8,
                   RecommendedUses = "Casual",
                   KindOfFabric = "Dry",
                   Composition = "Polyester",
                   MainMaterial = "Polyester",
                   SleeveType = "Like",
                   TypeOfCollar = "Round neck",
                   UnitsPerKit = 1,
                   WithRecycledMaterials = false,
                   ItsSporty = true
               });
           });
    }
}
