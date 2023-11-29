using Domain.Entities.Products.Technology.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Technology
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(
               new Game(
                   4,
                   "Marvel\'s Spider-Man: Miles Morales Standard Edition Sony PS5 Physical",
                   "With this Spider-Man game you will enjoy hours of fun and new challenges that will allow you to improve as a player.",
                   "2 days",
                   10,
                   4
                   ));

            ConfigureImageVO(builder);
            ConfigureSpecificationsVO(builder);
            ConfigurePriceVO(builder);
            ConfigureWarrantyVO(builder);
            ConfigureFlagsVO(builder);
            ConfigureDataVO(builder);
            ConfigureGameGeneralFeaturesOV(builder);
            ConfigureGameRequirementsOV(builder);
            ConfigureGameSpecificationsOV(builder);

        }
        private static void ConfigureSpecificationsVO(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.ProductSpecificationsObjectValue,
                sa =>
                {
                    sa.Property<int>("Id");
                    sa.HasKey("Id");
                    sa.HasData(new
                    {
                        Id = 4,
                        ProductModel = "Sony",
                        ProductBrand = "Sony",
                        ProductLine = "PS5",
                        ProductWeight = "100 g"
                    });
                });
        }
        private static void ConfigureImageVO(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.ProductImageObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 4,
                    MainImage = "https://http2.mlstatic.com/D_NQ_NP_739971-MLA44963396567_022021-O.webp",
                    ImageFirst = "https://http2.mlstatic.com/D_NQ_NP_717296-MLA44963321732_022021-O.webp",
                    ImageSecond = "https://http2.mlstatic.com/D_NQ_NP_902181-MLA44963396568_022021-O.webp",
                    ImageThird = "https://http2.mlstatic.com/D_NQ_NP_952087-MLU69953465194_062023-O.webp"
                });
            });
        }
        private static void ConfigurePriceVO(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.ProductPriceObjectValue,
             sa =>
             {
                 sa.Property<int>("Id");
                 sa.HasKey("Id");
                 sa.HasData(new
                 {
                     Id = 4,
                     Price = 30.99M,
                     HistoryPrice = 0.0M
                 });
             });
        }
        private static void ConfigureWarrantyVO(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.ProductWarrantyObjectValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 4,
                      WarrantyLength = "1-year warranty",
                      WarrantyInformation = "30-Day Limited Warranty"
                  });
              });
        }
        private static void ConfigureFlagsVO(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.ProductFlagsObjectValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 4,
                      IsDailyOffer = false,
                      IsBestSeller = true,
                      IsFavorite = false
                  });
              });
        }
        private static void ConfigureDataVO(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.ProductDataObjectValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 4,
                       ReleaseMonth = "June",
                       ReleaseYear = "2023"
                   });
               });
        }
        private static void ConfigureGameGeneralFeaturesOV(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.GameGeneralFeaturesObjectsValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 4,
                      Collection = "Spider man",
                      Saga = "30-Day Limited Warranty",
                      GameTitle = "Marvel\'s Spider-Man: Miles Morales",
                      Edition = "Standard Edition",
                      Platform = "PS5",
                      Developers = "Insomniac Games",
                      Publishers = "Sony",
                      Genres = "Action",
                      GameRating = 'T'
                  });
              });
        }
        private static void ConfigureGameRequirementsOV(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.GameRequirementsObjectsValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 4,
                      MinimumRAMRequirement = 60,
                      MinimumOperatingSystemsRequired = "PS5",
                      MinimumGraphicsProcessorsRequired = "V",
                      MinimumProcessorsRequired = "Ps5"
                  });
              });
        }
        private static void ConfigureGameSpecificationsOV(EntityTypeBuilder<Game> builder)
        {
            builder.OwnsOne(x => x.GameSpecificationsObjectsValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 4,
                      Format = "Physical",
                      AudioLanguages = "English",
                      SubtitleLanguages = "English, Portuguese",
                      ScreenLanguages = "English, Portuguese",
                      MaximumNumberOfOfflinePlayers = 1,
                      MaximumNumberOfOnlinePlayers = 1,
                      FileSize = 60,
                      ItsMultiplayer = false,
                      ItsOnline = false,
                      ItsOffline = true,
                      RequiresPeripheral = false
                  });
              });
        }
    }
}
