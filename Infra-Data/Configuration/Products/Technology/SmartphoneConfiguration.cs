using Domain.Entities.Products.Technology.Smartphones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra_Data.Configuration.Products.Technology
{
    public class SmartphoneConfiguration : IEntityTypeConfiguration<Smartphone>
    {
        public void Configure(EntityTypeBuilder<Smartphone> builder)
        {
            builder.HasData(
                new Smartphone(
                    1,
                    "Galaxy S23 Ultra 512GB Unlocked - Black",
                    "Introducing Galaxy S23 Ultra - a smartphone that takes innovation to new heights. With its crystal-clear camera resolution and stunning Night Mode powered by Nightography, you can capture and share unforgettable moments, regardless of lighting conditions. Powered by the fastest Snapdragon processor, multitasking and intense gaming become seamless. Enjoy the convenience of a built-in S Pen, allowing you to write, sketch, edit, and share from anywhere. All of this on a large display designed for gaming, streaming, creating, and more. Elevate your everyday experience with a device that's truly extraordinary and share the epic with Galaxy S23 Ultra.",
                    20,
                    1
                    ));

            ConfigureImageVO(builder);
            ConfigureSpecificationsVO(builder);
            ConfigurePriceVO(builder);
            ConfigureWarrantyVO(builder);
            ConfigureFlagsVO(builder);
            ConfigureDataVO(builder);
            ConfigureFeatureVO(builder);
            ConfigureDisplayVO(builder);
            ConfigureMemoryVO(builder);
            ConfigureCameraVO(builder);
            ConfigurePlatformVO(builder);
            ConfigureBatteryVO(builder);
            ConfigureDimensionsVO(builder);
        }
        private static void ConfigureSpecificationsVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.ProductSpecificationsObjectValue,
                sa =>
                {
                    sa.Property<int>("Id");
                    sa.HasKey("Id");
                    sa.HasData(new
                    {
                        Id = 1,
                        ProductModel = "S23 Ultra",
                        ProductBrand = "Samsung",
                        ProductLine = "Galaxy S",
                        ProductWeight = "233 g",
                        ProductType = "Smartphone"
                    });
                });
        }
        private static void ConfigureImageVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.ProductImageObjectValue,
            sa =>
            {
                sa.Property<int>("Id");
                sa.HasKey("Id");
                sa.HasData(new
                {
                    Id = 1,
                    MainImage = "https://http2.mlstatic.com/D_NQ_NP_856672-MLU70401529412_072023-O.webp",
                    ImageFirst = "https://http2.mlstatic.com/D_NQ_NP_945544-MLU70401529414_072023-O.webp",
                    ImageSecond = "https://http2.mlstatic.com/D_NQ_NP_808604-MLU70400221716_072023-O.webp",
                    ImageThird = "https://http2.mlstatic.com/D_NQ_NP_827555-MLU70400783806_072023-O.webp"
                });
            });
        }
        private static void ConfigurePriceVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.ProductPriceObjectValue,
             sa =>
             {
                 sa.Property<int>("Id");
                 sa.HasKey("Id");
                 sa.HasData(new
                 {
                     Id = 1,
                     Price = 4479.99M,
                     HistoryPrice = 6199.99M
                 });
             });
        }
        private static void ConfigureWarrantyVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.ProductWarrantyObjectValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 1,
                      WarrantyLength = "1-year warranty",
                      WarrantyInformation = "30-Day Limited Warranty"
                  });
              });
        }
        private static void ConfigureFlagsVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.ProductFlagsObjectValue,
              sa =>
              {
                  sa.Property<int>("Id");
                  sa.HasKey("Id");
                  sa.HasData(new
                  {
                      Id = 1,
                      IsDailyOffer = true,
                      IsBestSeller = false,
                      IsFavorite = true
                  });
              });
        }
        private static void ConfigureDataVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.ProductDataObjectValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 1,
                       ReleaseMonth = "June",
                       ReleaseYear = "2023"
                   });
               });
        }
        private static void ConfigureFeatureVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.SmartphoneFeatureObjectValue,
             sa =>
             {
                 sa.Property(x => x.CellNetworkTechnology).HasMaxLength(30).IsRequired();
                 sa.Property(x => x.VirtualAssistant).HasMaxLength(50).IsRequired();
                 sa.Property(x => x.ManufacturerPartNumber).HasMaxLength(50).IsRequired();
                 sa.Property(x => x.Color).HasMaxLength(20).IsRequired();

                 sa.Property<int>("Id");
                 sa.HasKey("Id");
                 sa.HasData(new
                 {
                     Id = 1,
                     CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G",
                     VirtualAssistant = "Samsung Bixby,Alexa,Google Assistant",
                     ManufacturerPartNumber = "SM-S918UZKFXAA",
                     Color = "Phantom Black"
                 });
             });
        }
        private static void ConfigureDisplayVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.SmartphoneDisplayObjectValue,
                sa =>
                {
                    sa.Property(x => x.DisplayType).HasMaxLength(30);
                    sa.Property(x => x.DisplayResolution).HasMaxLength(25);
                    sa.Property(x => x.DisplayProtection).HasMaxLength(40);

                    sa.Property<int>("Id");
                    sa.HasKey("Id");
                    sa.HasData(new
                    {
                        Id = 1,
                        DisplayType = "Dynamic AMOLED 2X",
                        DisplaySizeInche = 6.8,
                        DisplayResolution = "1440 x 3088 pixels",
                        DisplayProtection = "Corning Gorilla Glass Victus 2"
                    });
                });
        }
        private static void ConfigureMemoryVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.SmartphoneMemoryObjectValue,
               sa =>
               {
                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 1,
                       RAMGB = 16,
                       StorageGB = 512
                   });
               });
        }
        private static void ConfigureCameraVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.SmartphoneCameraObjectValue,
               sa =>
               {
                   sa.Property(x => x.MainCameraSpec).HasMaxLength(15).IsRequired();
                   sa.Property(x => x.MainCameraFeature).HasMaxLength(50).IsRequired();
                   sa.Property(x => x.SelfieCameraSpec).HasMaxLength(15).IsRequired();
                   sa.Property(x => x.SelfieCameraFeature).HasMaxLength(50).IsRequired();

                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 1,
                       MainCameraSpec = "200 MPx",
                       MainCameraFeature = "(Quad) 200 MP + 10 MP + 10 MP + 12 MP",
                       SelfieCameraSpec = "12 MP",
                       SelfieCameraFeature = "LED flash, auto-HDR, panorama"
                   });
               });
        }
        private static void ConfigurePlatformVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.SmartphonePlatformObjectValue,
           sa =>
           {
               sa.Property(x => x.OperatingSystem).HasMaxLength(15).IsRequired();
               sa.Property(x => x.Chipset).HasMaxLength(50).IsRequired();
               sa.Property(x => x.GPU).HasMaxLength(15).IsRequired();
               sa.Property(x => x.CPU).HasMaxLength(15).IsRequired();

               sa.Property<int>("Id");
               sa.HasKey("Id");
               sa.HasData(new
               {
                   Id = 1,
                   OperatingSystem = "Android",
                   Chipset = "Qualcomm SM8550-AC Snapdragon 8 Gen 2",
                   GPU = "Adreno 740",
                   CPU = "Octa-core"
               });
           });
        }
        private static void ConfigureDimensionsVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.SmartphoneDimensionsObjectValue,
                  sa =>
                  {
                      sa.Property<int>("Id");
                      sa.HasKey("Id");
                      sa.HasData(new
                      {
                          Id = 1,
                          HeightInche = 6.43,
                          WidthInche = 3.07,
                          ThicknessInche = 0.35
                      });
                  });
        }
        private static void ConfigureBatteryVO(EntityTypeBuilder<Smartphone> builder)
        {
            builder.OwnsOne(x => x.SmartphoneBatteryObjectValue,
                sa =>
                {
                    sa.Property(b => b.BatteryType)
                        .HasMaxLength(15)
                        .IsRequired();

                    sa.Property<int>("Id");
                    sa.HasKey("Id");
                    sa.HasData(new
                    {
                        Id = 1,
                        BatteryType = "Li-Ion",
                        BatteryCapacitymAh = 5000,
                        IsBatteryRemovable = false
                    });
                });
        }
    }
}
