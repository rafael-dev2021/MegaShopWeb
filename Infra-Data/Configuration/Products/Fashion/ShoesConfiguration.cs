using Domain.Entities.Products.Fashion.Shoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Fashion
{
    public class ShoesConfiguration : IEntityTypeConfiguration<Shoes>
    {
        public void Configure(EntityTypeBuilder<Shoes> builder)
        {
            builder.HasData(
                new Shoes(
                    2,
                    "Nike Sb Chron 2 Men\'s Shoes",
                    "Flexible and ventilated, the Nike SB Chron 2 is a worthy follow-up to its predecessor. The refreshed design includes updates to the collar and heel for an improved fit while maintaining the comfort and performance you expect from Nike SB.",
                    "5 days",
                    15,
                    2
                    ));
            ConfigureSpecificationsVO(builder);
            ConfigureImageVO(builder);
            ConfigurePriceVO(builder);
            ConfigureWarrantyVO(builder);
            ConfigureFlagsVO(builder);
            ConfigureDataVO(builder);
            ConfigureShoesDesignOV(builder);
            ConfigureShoesGeneralFeaturesOV(builder);
            ConfigureShoesMaterialsOV(builder);
            ConfigureShoesSpecificationsOV(builder);
        }
        private static void ConfigureSpecificationsVO(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ProductSpecificationsObjectValue,
                sa =>
                {
                    sa.Property<int>("Id");
                    sa.HasKey("Id");
                    sa.HasData(new
                    {
                        Id = 2,
                        ProductModel = "DM3493",
                        ProductBrand = "Nike",
                        ProductLine = "SB",
                        ProductWeight = "368,5 g"
                    });
                });
        }
        private static void ConfigureImageVO(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ProductImageObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 2,
                    MainImage = "https://http2.mlstatic.com/D_NQ_NP_808923-MLB68964867575_042023-O.webp",
                    ImageFirst = "https://http2.mlstatic.com/D_NQ_NP_701088-MLB68964867585_042023-O.webp",
                    ImageSecond = "https://http2.mlstatic.com/D_NQ_NP_917859-MLB68964867581_042023-O.webp",
                    ImageThird = "https://http2.mlstatic.com/D_NQ_NP_696501-MLB68964867579_042023-O.webp"
                });
            });
        }
        private static void ConfigurePriceVO(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ProductPriceObjectValue,
             sa =>
             {
                 sa.Property<int>("Id");
                 sa.HasKey("Id");
                 sa.HasData(new
                 {
                     Id = 2,
                     Price = 52.99M,
                     HistoryPrice = 94.99M
                 });
             });
        }
        private static void ConfigureWarrantyVO(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ProductWarrantyObjectValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 2,
                      WarrantyLength = "1-year warranty",
                      WarrantyInformation = "45-Day Limited Warranty"
                  });
              });
        }
        private static void ConfigureFlagsVO(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ProductFlagsObjectValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 2,
                      IsDailyOffer = true,
                      IsBestSeller = false,
                      IsFavorite = true
                  });
              });
        }
        private static void ConfigureDataVO(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ProductDataObjectValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 2,
                       ReleaseMonth = "June",
                       ReleaseYear = "2023"
                   });
               });
        }
        private static void ConfigureShoesDesignOV(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ShoesDesignObjectValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 2,
                       AdjustmentTypes = "Shoelaces",
                       TypeOfPipe = ""
                   });
               });
        }
        private static void ConfigureShoesGeneralFeaturesOV(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ShoesGeneralFeaturesObjectValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 2,
                       Gender = "No gender",
                       Version = "two",
                       Age = "Adults",
                       Color = "Black"
                   });
               });
        }
        private static void ConfigureShoesMaterialsOV(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ShoesMaterialsObjectValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 2,
                       MaterialsFromAbroad = "",
                       InteriorMaterials = "",
                       SoleMaterials = "",
                   });
               });
        }
        private static void ConfigureShoesSpecificationsOV(EntityTypeBuilder<Shoes> builder)
        {
            builder.OwnsOne(x => x.ShoesSpecificationsObjectValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 2,
                       Style = "Urban",
                       RecommendedSports = "skateboarding/casual",
                       Size = "7.5",
                   });
               });
        }
    }

}
