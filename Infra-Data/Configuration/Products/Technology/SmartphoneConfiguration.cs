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
                    "Samsung Galaxy S23 Ultra 512GB Unlocked - Black",
                    "Maximum security so that only you can access your team. You can choose between the fingerprint sensor to activate your phone with a tap, or facial recognition that allows you to unlock up to 30% faster.",
                    20,
                    1
                ),
                new Smartphone(
                    2,
                    "Samsung Galaxy S23 Ultra 256GB - Violet",
                    "Maximum security so that only you can access your team. You can choose between the fingerprint sensor to activate your phone with a tap, or facial recognition that allows you to unlock up to 30% faster.",
                    25,
                    1
                ),
                  new Smartphone(
                    3,
                    "Apple iPhone 15 Pro (512 GB) - Titanium Blue",
                    "FORGED FROM TITANIUM — iPhone 15 Pro features a rugged, lightweight design made from aerospace-grade titanium. On the back, textured matte glass and, on the front, Ceramic Shield, more resistant than any smartphone glass. It\'s also tough against splashes, water, and dust.",
                    15,
                    1
                ),
                    new Smartphone(
                    4,
                    "Apple iPhone 15 Pro (128 GB) - Titanium White",
                    "FORGED FROM TITANIUM — iPhone 15 Pro features a rugged, lightweight design made from aerospace-grade titanium. On the back, textured matte glass and, on the front, Ceramic Shield, more resistant than any smartphone glass. It\'s also tough against splashes, water, and dust.",
                    10,
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

                 sa.HasData(new
                 {
                     Id = 2,
                     ProductModel = "S23 Ultra",
                     ProductBrand = "Samsung",
                     ProductLine = "Galaxy S",
                     ProductWeight = "235 g",
                     ProductType = "Smartphone"
                 });
                 sa.HasData(new
                 {
                     Id = 3,
                     ProductModel = "iPhone 15 Pro",
                     ProductBrand = "Apple",
                     ProductLine = "iPhone",
                     ProductWeight = "235 g",
                     ProductType = "Smartphone"
                 });
                 sa.HasData(new
                 {
                     Id = 4,
                     ProductModel = "iPhone 15 Pro",
                     ProductBrand = "Apple",
                     ProductLine = "iPhone",
                     ProductWeight = "235 g",
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
                sa.HasData(new
                {
                    Id = 2,
                    MainImage = "https://http2.mlstatic.com/D_NQ_NP_683947-MLU73106437489_112023-O.webp",
                    ImageFirst = "https://http2.mlstatic.com/D_NQ_NP_690989-MLU72932986551_112023-O.webp",
                    ImageSecond = "https://http2.mlstatic.com/D_NQ_NP_612226-MLU72932986555_112023-O.webp",
                    ImageThird = "https://http2.mlstatic.com/D_NQ_NP_683459-MLU72932986549_112023-O.webp"
                });
                sa.HasData(new
                {
                    Id = 3,
                    MainImage = "https://http2.mlstatic.com/D_NQ_NP_918178-MLA71783088444_092023-O.webp",
                    ImageFirst = "https://http2.mlstatic.com/D_NQ_NP_918178-MLA71783088444_092023-O.webp",
                    ImageSecond = "https://http2.mlstatic.com/D_NQ_NP_829742-MLA71783365702_092023-O.webp",
                    ImageThird = "https://http2.mlstatic.com/D_NQ_NP_715495-MLA71783365704_092023-O.webps"
                });
                sa.HasData(new
                {
                    Id = 4,
                    MainImage = "https://http2.mlstatic.com/D_NQ_NP_812116-MLA71783168214_092023E-O.webp",
                    ImageFirst = "https://http2.mlstatic.com/D_NQ_NP_812116-MLA71783168214_092023E-O.webp",
                    ImageSecond = "https://http2.mlstatic.com/D_NQ_NP_658271-MLA71782871766_092023-O.webp",
                    ImageThird = "https://http2.mlstatic.com/D_NQ_NP_998898-MLA71782901894_092023-O.webp"
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
                     Price = 2179.99M,
                     HistoryPrice = 2299.99M
                 });
                 sa.HasData(new
                 {
                     Id = 2,
                     Price = 1624.99M,
                     HistoryPrice = 2199.99M
                 });
                 sa.HasData(new
                 {
                     Id = 3,
                     Price = 2035.99M,
                     HistoryPrice = 2199.99M
                 });
                 sa.HasData(new
                 {
                     Id = 4,
                     Price = 1624.99M,
                     HistoryPrice = 1799.99M
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
                  sa.HasData(new
                  {
                      Id = 2,
                      WarrantyLength = "1-year warranty",
                      WarrantyInformation = "30-Day Limited Warranty"
                  });
                  sa.HasData(new
                  {
                      Id = 3,
                      WarrantyLength = "1-year warranty",
                      WarrantyInformation = "30-Day Limited Warranty"
                  });
                  sa.HasData(new
                  {
                      Id = 4,
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
                  sa.HasData(new
                  {
                      Id = 2,
                      IsDailyOffer = true,
                      IsBestSeller = false,
                      IsFavorite = true
                  });
                  sa.HasData(new
                  {
                      Id = 3,
                      IsDailyOffer = true,
                      IsBestSeller = false,
                      IsFavorite = false
                  });
                  sa.HasData(new
                  {
                      Id = 4,
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
                   sa.HasData(new
                   {
                       Id = 2,
                       ReleaseMonth = "August",
                       ReleaseYear = "2022"
                   });
                   sa.HasData(new
                   {
                       Id = 3,
                       ReleaseMonth = "Februery",
                       ReleaseYear = "2023"
                   });
                   sa.HasData(new
                   {
                       Id = 4,
                       ReleaseMonth = "March",
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
                 sa.HasData(new
                 {
                     Id = 2,
                     CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G",
                     VirtualAssistant = "Samsung Bixby,Alexa,Google Assistant",
                     ManufacturerPartNumber = "SM-B518UZKFX22",
                     Color = "Violet"
                 });
                 sa.HasData(new
                 {
                     Id = 3,
                     CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G",
                     VirtualAssistant = "Apple Watch,HomePod,Siri Assistant",
                     ManufacturerPartNumber = "AA-12SF7832SD301EW3",
                     Color = "Titanium Blue"
                 });
                 sa.HasData(new
                 {
                     Id = 4,
                     CellNetworkTechnology = "WCDMA (UMTS) / GSM / 5G",
                     VirtualAssistant = "Apple Watch,HomePod,Siri Assistant",
                     ManufacturerPartNumber = "AA-12VD783HR230SW19",
                     Color = "Titanium White"
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
                        DisplayType = "Dynamic AMOLED 2X 120 Hz",
                        DisplaySizeInche = 6.8,
                        DisplayResolution = "1440 px x 3088 px",
                        DisplayProtection = "Corning Gorilla Glass Victus 2"
                    });
                    sa.HasData(new
                    {
                        Id = 2,
                        DisplayType = "Dynamic AMOLED 2X",
                        DisplaySizeInche = 6.8,
                        DisplayResolution = "1440 px x 3088 px",
                        DisplayProtection = "Corning Gorilla Glass Victus 2"
                    });
                    sa.HasData(new
                    {
                        Id = 3,
                        DisplayType = "Super Retina XDR",
                        DisplaySizeInche = 6.1,
                        DisplayResolution = "2556 px x 1179 px",
                        DisplayProtection = "Corning Gorilla Glass Victus 2"
                    });
                    sa.HasData(new
                    {
                        Id = 4,
                        DisplayType = "Super Retina XDR",
                        DisplaySizeInche = 6.1,
                        DisplayResolution = "2556 px x 1179 px",
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
                       RAMGB = 12,
                       StorageGB = 512
                   });
                   sa.HasData(new
                   {
                       Id = 2,
                       RAMGB = 8,
                       StorageGB = 258
                   });
                   sa.HasData(new
                   {
                       Id = 3,
                       RAMGB = 8,
                       StorageGB = 512
                   });
                   sa.HasData(new
                   {
                       Id = 4,
                       RAMGB = 8,
                       StorageGB = 128
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
                   sa.Property(x => x.SelfieCameraFeature).HasMaxLength(100).IsRequired();

                   sa.Property<int>("Id");
                   sa.HasKey("Id");
                   sa.HasData(new
                   {
                       Id = 1,
                       MainCameraSpec = "200 Mpx",
                       MainCameraFeature = "(Quad) 200 MP + 10 MP + 10 MP + 12 MP",
                       SelfieCameraSpec = "12 Mpx",
                       SelfieCameraFeature = "LED flash, auto-HDR, panorama"
                   });
                   sa.HasData(new
                   {
                       Id = 2,
                       MainCameraSpec = "200 Mpx",
                       MainCameraFeature = "200 Mpx/12 Mpx/10 Mpx/10 Mpx",
                       SelfieCameraSpec = "12 Mpx",
                       SelfieCameraFeature = "LED flash, auto-HDR, panorama"
                   });
                   sa.HasData(new
                   {
                       Id = 3,
                       MainCameraSpec = "48 Mpx",
                       MainCameraFeature = "48 Mpx/12 Mpx/12 Mpx",
                       SelfieCameraSpec = "12 Mpx",
                       SelfieCameraFeature = "Photonic engine, Deep fusion, Smart HDR 4, Portrait mode, Portrait lighting with six effects,"
                   });
                   sa.HasData(new
                   {
                       Id = 4,
                       MainCameraSpec = "48 Mpx",
                       MainCameraFeature = "48 Mpx/12 Mpx/12 Mpx",
                       SelfieCameraSpec = "12 Mpx",
                       SelfieCameraFeature = "Photonic engine, Deep fusion, Smart HDR 4, Portrait mode, Portrait lighting with six effects,"
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
               sa.Property(x => x.GPU).HasMaxLength(30).IsRequired();
               sa.Property(x => x.CPU).HasMaxLength(30).IsRequired();

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
               sa.HasData(new
               {
                   Id = 2,
                   OperatingSystem = "Android",
                   Chipset = "Qualcomm SM8550-AC Snapdragon 8 Gen 2",
                   GPU = "Adreno 740",
                   CPU = "Octa-Core of up to 3.36GHz"
               });
               sa.HasData(new
               {
                   Id = 3,
                   OperatingSystem = "iOS",
                   Chipset = "Apple A17 Pro",
                   GPU = "5 cores",
                   CPU = "Chip A16 Bionic"
               });
               sa.HasData(new
               {
                   Id = 4,
                   OperatingSystem = "iOS",
                   Chipset = "Apple A17 Pro",
                   GPU = "5 cores",
                   CPU = "Chip A16 Bionic"
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
                          HeightInche = 163.4,
                          WidthInche = 78.1,
                          ThicknessInche = 8.9
                      });
                      sa.HasData(new
                      {
                          Id = 2,
                          HeightInche = 163.4,
                          WidthInche = 78.1,
                          ThicknessInche = 8.9
                      });
                      sa.HasData(new
                      {
                          Id = 3,
                          HeightInche = 160.9,
                          WidthInche = 77.8,
                          ThicknessInche = 7.80
                      });
                      sa.HasData(new
                      {
                          Id = 4,
                          HeightInche = 160.9,
                          WidthInche = 77.8,
                          ThicknessInche = 7.80
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
                    sa.HasData(new
                    {
                        Id = 2,
                        BatteryType = "Lithium Ion",
                        BatteryCapacitymAh = 5000,
                        IsBatteryRemovable = false
                    });
                    sa.HasData(new
                    {
                        Id = 3,
                        BatteryType = "Lithium Ion",
                        BatteryCapacitymAh = 5000,
                        IsBatteryRemovable = false
                    });
                    sa.HasData(new
                    {
                        Id = 4,
                        BatteryType = "Lithium Ion",
                        BatteryCapacitymAh = 5000,
                        IsBatteryRemovable = false
                    });
                });
        }
    }
}
