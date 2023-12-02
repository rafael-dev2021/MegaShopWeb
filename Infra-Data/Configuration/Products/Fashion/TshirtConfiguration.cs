using Domain.Entities.Products.Fashion.Tshirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Fashion
{
    public class TshirtConfiguration : IEntityTypeConfiguration<Tshirt>
    {
        public void Configure(EntityTypeBuilder<Tshirt> builder)
        {
            builder.HasData(
               new Tshirt(
                   3,
                   "Top Nike Swoosh Woman",
                   "The Nike Classic Swoosh Futura medium support women\'s workout top offers long-lasting comfort during training with sweat-wicking fabric and a compression fit.",
                   5,
                   2
                   ));
            ConfigureSpecificationsVO(builder);
            ConfigureImageVO(builder);
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
                        Id = 3,
                        ProductModel = "T-Shirt",
                        ProductBrand = "Nike",
                        ProductLine = "",
                        ProductWeight = "200 g",
                        ProductType = "T-Shirt"
                    });
                });
        }
        private static void ConfigureImageVO(EntityTypeBuilder<Tshirt> builder)
        {
            builder.OwnsOne(x => x.ProductImageObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 3,
                    MainImage = "https://imgnike-a.akamaihd.net/768x768/002897ID.jpg",
                    ImageFirst = "https://imgnike-a.akamaihd.net/768x768/002897IDA1.jpg",
                    ImageSecond = "https://imgnike-a.akamaihd.net/768x768/002897IDA4.jpg",
                    ImageThird = "https://imgnike-a.akamaihd.net/768x768/002897IDA5.jpg"
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
                     Id = 3,
                     Price = 16.99M,
                     HistoryPrice = 0.0M
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
                      Id = 3,
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
                      Id = 3,
                      IsDailyOffer = false,
                      IsFavorite = true,
                      IsBestSeller = true
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
                       Id = 3,
                       ReleaseMonth = "June",
                       ReleaseYear = "2023"
                   });
               });
        }
        private static void ConfigureTshirtMainFeaturesOV(EntityTypeBuilder<Tshirt> builder)
        {
            builder.OwnsOne(x => x.TshirtMainFeaturesObectsValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 3,
                       Gender = "Woman",
                       Age = "Adult",
                       TypeOfClothing = "T-shirt",
                       FabricDesign = "Straight",
                       Size = "S"
                   });
               });
        }
        private static void ConfigureTshirtOtherFeaturesOV(EntityTypeBuilder<Tshirt> builder)
        {
            builder.OwnsOne(x => x.TshirtOtherFeaturesObectsValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 3,
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
               });
        }
    }
}
