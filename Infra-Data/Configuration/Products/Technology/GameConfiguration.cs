﻿using Domain.Entities.Products.Technology.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Technology;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasData(
           new Game(
               5,
               "Marvel\'s Spider-Man: Miles Morales Standard Edition Sony PS5",
               "With this Spider-Man game you will enjoy hours of fun and new challenges that will allow you to improve as a player.",
               [
                   "https://http2.mlstatic.com/D_NQ_NP_739971-MLA44963396567_022021-O.webp",
                   "https://http2.mlstatic.com/D_NQ_NP_717296-MLA44963321732_022021-O.webp",
                   "https://http2.mlstatic.com/D_NQ_NP_902181-MLA44963396568_022021-O.webp",
                   "https://http2.mlstatic.com/D_NQ_NP_952087-MLU69953465194_062023-O.webp"
               ],
               10,
               3
               ),
            new Game(
               6,
               "God of War Ragnarök Standard Edition Sony PS5",
               "With this God of War game you will enjoy hours of fun and new challenges that will allow you to improve as a player. You will be able to share each game with people from all over the world as you can connect online.",
               [
                   "https://http2.mlstatic.com/D_NQ_NP_834716-MLU72751588558_112023-O.webp",
                   "https://http2.mlstatic.com/D_NQ_NP_924074-MLU69483138400_052023-O.webp",
                   "https://http2.mlstatic.com/D_NQ_NP_662378-MLU69483138404_052023-O.webp",
                   "https://http2.mlstatic.com/D_NQ_NP_852774-MLU69482634062_052023-O.webp"
               ],
               15,
               3
               ));

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
                    Id = 5,
                    ProductModel = "Sony",
                    ProductBrand = "Sony",
                    ProductLine = "PS5",
                    ProductWeight = "100 g",
                    ProductType = "Video game"
                });
                sa.HasData(new
                {
                    Id = 6,
                    ProductModel = "Sony",
                    ProductBrand = "Sony",
                    ProductLine = "PS5",
                    ProductWeight = "100 g",
                    ProductType = "Video game"
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
                 Id = 5,
                 Price = 30.99M,
                 HistoryPrice = 0.0M
             });
             sa.HasData(new
             {
                 Id = 6,
                 Price = 38.99M,
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
                  Id = 5,
                  WarrantyLength = "1-year warranty",
                  WarrantyInformation = "30-Day Limited Warranty"
              });
              sa.HasData(new
              {
                  Id = 6,
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
                  Id = 5,
                  IsDailyOffer = false,
                  IsBestSeller = true,
                  IsFavorite = true
              });
              sa.HasData(new
              {
                  Id = 6,
                  IsDailyOffer = false,
                  IsBestSeller = true,
                  IsFavorite = true
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
                   Id = 5,
                   ReleaseMonth = "June",
                   ReleaseYear = "2023"
               });
               sa.HasData(new
               {
                   Id = 6,
                   ReleaseMonth = "July",
                   ReleaseYear = "2022"
               });
           });
    }
    private static void ConfigureGameGeneralFeaturesOV(EntityTypeBuilder<Game> builder)
    {
        builder.OwnsOne(x => x.GameGeneralFeaturesObjectsValue,
          sa =>
          {
              sa.Property(x => x.Collection)
                .HasMaxLength(25)
                .IsRequired();
              sa.Property(x => x.Saga)
                .HasMaxLength(40)
                .IsRequired();
              sa.Property(x => x.GameTitle)
                .HasMaxLength(50)
                .IsRequired();
              sa.Property(x => x.Edition)
                .HasMaxLength(25)
                .IsRequired();
              sa.Property(x => x.Platform)
                .HasMaxLength(15)
                .IsRequired();
              sa.Property(x => x.Developers)
                .HasMaxLength(40)
                .IsRequired();
              sa.Property(x => x.Publishers)
                .HasMaxLength(15)
                .IsRequired();
              sa.Property(x => x.Genres)
                .HasMaxLength(25)
                .IsRequired();
              sa.Property(x => x.GameRating)
                .IsRequired();
              sa.Property<int>("Id");
              sa.HasKey("Id");
              sa.HasData(new
              {
                  Id = 5,
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
              sa.HasData(new
              {
                  Id = 6,
                  Collection = "God of War",
                  Saga = "30-Day Limited Warranty",
                  GameTitle = "God of War Ragnarök",
                  Edition = "Standard Edition",
                  Platform = "PS5",
                  Developers = "SIE Santa Monica Studio",
                  Publishers = "Sony",
                  Genres = "Action",
                  GameRating = 'M'
              });
          });
    }
    private static void ConfigureGameRequirementsOV(EntityTypeBuilder<Game> builder)
    {
        builder.OwnsOne(x => x.GameRequirementsObjectsValue,
          sa =>
          {
              sa.Property(x => x.MinimumRAMRequirement)
                .HasConversion<int>();
              sa.Property(x => x.MinimumOperatingSystemsRequired)
                .HasMaxLength(10)
                .IsRequired();
              sa.Property(x => x.MinimumGraphicsProcessorsRequired)
                .HasMaxLength(10);
              sa.Property(x => x.MinimumProcessorsRequired)
                .HasMaxLength(10);
              sa.Property<int>("Id");
              sa.HasKey("Id");
              sa.HasData(new
              {
                  Id = 5,
                  MinimumRAMRequirement = 60,
                  MinimumOperatingSystemsRequired = "PS5",
                  MinimumGraphicsProcessorsRequired = "V",
                  MinimumProcessorsRequired = "Ps5"
              });
              sa.HasData(new
              {
                  Id = 6,
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
              sa.Property(x => x.Format)
              .HasMaxLength(20)
              .IsRequired();
              sa.Property(x => x.AudioLanguages)
              .HasMaxLength(50)
              .IsRequired();
              sa.Property(x => x.SubtitleLanguages)
              .HasMaxLength(30)
              .IsRequired();
              sa.Property(x => x.ScreenLanguages)
              .HasMaxLength(30)
              .IsRequired();
              sa.Property(x => x.MaximumNumberOfOfflinePlayers)
              .HasConversion<int>()
              .IsRequired(); sa.Property(x => x.MaximumNumberOfOnlinePlayers)
              .HasConversion<int>()
              .IsRequired();
              sa.Property(x => x.FileSize)
              .HasConversion<int>()
              .IsRequired();
              sa.Property(x => x.ItsMultiplayer)
             .HasConversion<bool>();
              sa.Property(x => x.ItsOnline)
             .HasConversion<bool>();
              sa.Property(x => x.ItsOffline)
             .HasConversion<bool>();
              sa.Property(x => x.RequiresPeripheral)
             .HasConversion<bool>();
              sa.Property<int>("Id");
              sa.HasKey("Id");
              sa.HasData(new
              {
                  Id = 5,
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
              sa.HasData(new
              {
                  Id = 6,
                  Format = "Physical",
                  AudioLanguages = "English, Spanish, Portuguese",
                  SubtitleLanguages = "Spanish, English, Portuguese",
                  ScreenLanguages = "Spanish, English, Portuguese",
                  MaximumNumberOfOfflinePlayers = 1,
                  MaximumNumberOfOnlinePlayers = 1,
                  FileSize = 91,
                  ItsMultiplayer = false,
                  ItsOnline = true,
                  ItsOffline = true,
                  RequiresPeripheral = false
              });
          });
    }
}
