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
                    "Nike Air Max Excee",
                    "Buoyed to the comfort you\'ve come to trust, the Air Max Excee meets the needs of your 9 to 5 while keeping your outfit on-point with rich textures. These sneakers deliver just what you\'re looking for—soft cushioning that\'s easy to style.\r\n\r\n",
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
                        ProductWeight = "368,5 g",
                        ProductType = "Shoes"
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
                    MainImage = "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/349d779a-6d86-4982-9c0f-93f979038cc4/court-vision-low-next-nature-womens-shoes-ZkMMBG.png",
                    ImageFirst = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f7c941ab-7e44-4819-9483-adb9cd082787/court-vision-low-next-nature-womens-shoes-ZkMMBG.png",
                    ImageSecond = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/a682c7f1-a6e3-4387-b408-ebee5aae8afc/court-vision-low-next-nature-womens-shoes-ZkMMBG.png",
                    ImageThird = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f22e12cb-a84f-40af-a864-3c20fa958899/court-vision-low-next-nature-womens-shoes-ZkMMBG.png"
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
                     Price = 95.99M,
                     HistoryPrice = 0.0M
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
                      IsDailyOffer = false,
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
                       Gender = "Woman",
                       Version = "two",
                       Age = "Adult",
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
