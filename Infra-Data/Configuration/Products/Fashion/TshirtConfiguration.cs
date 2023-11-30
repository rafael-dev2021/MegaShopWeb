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
                   "Nike Dry Fabric T-Shirt",
                   "Size and weekends Avoid returns, compare the measurements provided with similar products of yours, even if you have any doubts, call us directly or ask questions.",
                   "3 days",
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
                        ProductWeight = "200 g"
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
                    MainImage = "https://http2.mlstatic.com/D_NQ_NP_643982-MLB71224535087_082023-O.webp",
                    ImageFirst = "https://http2.mlstatic.com/D_NQ_NP_788840-MLB71224485901_082023-O.webp",
                    ImageSecond = "https://http2.mlstatic.com/D_NQ_NP_623224-MLB71224535095_082023-O.webp",
                    ImageThird = "https://http2.mlstatic.com/D_NQ_NP_706933-MLB71224545183_082023-O.webp"
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
                       Gender = "Masculine",
                       Age = "Adults",
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
