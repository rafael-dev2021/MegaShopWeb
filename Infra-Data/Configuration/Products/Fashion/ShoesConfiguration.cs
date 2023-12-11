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
                    9,
                    "Nike Streakfly",
                    "Buoyed to the comfort you\'ve come to trust, the Air Max Excee meets the needs of your 9 to 5 while keeping your outfit on-point with rich textures. These sneakers deliver just what you\'re looking for—soft cushioning that\'s easy to style.",
                    15,
                    2
                    ),
                 new Shoes(
                    10,
                    "Suede Classic XXI Sneakers",
                    "The Suede hit the scene in 1968 and has been changing the game ever since. It’s been worn by icons of every generation, and it’s stayed classic through it all. Instantly recognizable and constantly reinvented, Suede’s legacy continues to grow and be legitimized by the authentic and expressive individuals that embrace the iconic shoe. Be apart of the history of Suede.",
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
                        Id = 9,
                        ProductModel = "DM3493",
                        ProductBrand = "Nike",
                        ProductLine = "SB",
                        ProductWeight = "368,5 g",
                        ProductType = "Shoes"
                    });
                    sa.HasData(new
                    {
                        Id = 10,
                        ProductModel = "Basketball Classic XXI sneakers",
                        ProductBrand = "Puma",
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
                    Id = 9,
                    MainImage = "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/24d5a5ec-db76-4512-99a8-36231b9a9b41/streakfly-road-racing-shoes-8rTxtR.png",
                    ImageFirst = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/97fb810e-5803-43f5-98ac-67c8763deb15/streakfly-road-racing-shoes-8rTxtR.png",
                    ImageSecond = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/6d25c69b-b08b-4cc7-b97d-8384e196951f/streakfly-road-racing-shoes-8rTxtR.png",
                    ImageThird = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/54e264aa-a85f-4152-b409-ed0372924d81/streakfly-road-racing-shoes-8rTxtR.png"
                });
                sa.HasData(new
                {
                    Id = 10,
                    MainImage = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/sv01/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers",
                    ImageFirst = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/mod02/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers",
                    ImageSecond = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/mod03/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers",
                    ImageThird = "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/bv/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers"
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
                     Id = 9,
                     Price = 71.99M,
                     HistoryPrice = 95.0M
                 });
                 sa.HasData(new
                 {
                     Id = 10,
                     Price = 75.99M,
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
                      Id = 9,
                      WarrantyLength = "1-year warranty",
                      WarrantyInformation = "45-Day Limited Warranty"
                  });
                  sa.HasData(new
                  {
                      Id = 10,
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
                      Id = 9,
                      IsDailyOffer = true,
                      IsBestSeller = false,
                      IsFavorite = true
                  });
                  sa.HasData(new
                  {
                      Id = 10,
                      IsDailyOffer = false,
                      IsBestSeller = true,
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
                       Id = 9,
                       ReleaseMonth = "June",
                       ReleaseYear = "2023"
                   });
                   sa.HasData(new
                   {
                       Id = 10,
                       ReleaseMonth = "October",
                       ReleaseYear = "2022"
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
                       Id = 9,
                       AdjustmentTypes = "Shoelaces",
                       TypeOfPipe = "Middle pipe"
                   });
                   sa.HasData(new
                   {
                       Id = 10,
                       AdjustmentTypes = "Shoelaces",
                       TypeOfPipe = "Middle pipe"
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
                       Id = 9,
                       Gender = "Woman",
                       Version = "two",
                       Age = "Adult",
                       Color = "Pink/Gold and Black"
                   });
                   sa.HasData(new
                   {
                       Id = 10,
                       Gender = "Man",
                       Version = "One",
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
                       Id = 9,
                       MaterialsFromAbroad = "Leather",
                       InteriorMaterials = "Cotton",
                       SoleMaterials = "Rubber",
                   });
                   sa.HasData(new
                   {
                       Id = 10,
                       MaterialsFromAbroad = "Leather",
                       InteriorMaterials = "Cotton",
                       SoleMaterials = "Rubber",
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
                       Id = 9,
                       Style = "Urban",
                       RecommendedSports = "skateboarding/casual",
                       Size = "7.5",
                   });
                   sa.HasData(new
                   {
                       Id = 10,
                       Style = "Urban",
                       RecommendedSports = "skateboarding/casual",
                       Size = "7.5",
                   });
               });
        }
    }

}
