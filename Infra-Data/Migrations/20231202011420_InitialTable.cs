using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra_Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ShoesDesignObjectValue_AdjustmentTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesDesignObjectValue_TypeOfPipe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesGeneralFeaturesObjectValue_Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesGeneralFeaturesObjectValue_Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesGeneralFeaturesObjectValue_Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesGeneralFeaturesObjectValue_Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesMaterialsObjectValue_MaterialsFromAbroad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesMaterialsObjectValue_InteriorMaterials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesMaterialsObjectValue_SoleMaterials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesSpecificationsObjectValue_Style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesSpecificationsObjectValue_RecommendedSports = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoesSpecificationsObjectValue_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDataObjectValue_ReleaseMonth = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    ProductDataObjectValue_ReleaseYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ProductFlagsObjectValue_IsDailyOffer = table.Column<bool>(type: "bit", nullable: true),
                    ProductFlagsObjectValue_IsFavorite = table.Column<bool>(type: "bit", nullable: true),
                    ProductFlagsObjectValue_IsBestSeller = table.Column<bool>(type: "bit", nullable: true),
                    ProductImageObjectValue_MainImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductImageObjectValue_ImageFirst = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductImageObjectValue_ImageSecond = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductImageObjectValue_ImageThird = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductPriceObjectValue_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductPriceObjectValue_HistoryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductSpecificationsObjectValue_ProductModel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProductSpecificationsObjectValue_ProductBrand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProductSpecificationsObjectValue_ProductLine = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProductSpecificationsObjectValue_ProductWeight = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProductSpecificationsObjectValue_ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductWarrantyObjectValue_WarrantyLength = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ProductWarrantyObjectValue_WarrantyInformation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TshirtOtherFeaturesObectsValue_RecommendedUses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtOtherFeaturesObectsValue_KindOfFabric = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtOtherFeaturesObectsValue_Composition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtOtherFeaturesObectsValue_MainMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtOtherFeaturesObectsValue_SleeveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtOtherFeaturesObectsValue_TypeOfCollar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtOtherFeaturesObectsValue_UnitsPerKit = table.Column<int>(type: "int", nullable: true),
                    TshirtOtherFeaturesObectsValue_WithRecycledMaterials = table.Column<bool>(type: "bit", nullable: true),
                    TshirtOtherFeaturesObectsValue_ItsSporty = table.Column<bool>(type: "bit", nullable: true),
                    TshirtMainFeaturesObectsValue_Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtMainFeaturesObectsValue_Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtMainFeaturesObectsValue_TypeOfClothing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtMainFeaturesObectsValue_FabricDesign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtMainFeaturesObectsValue_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_Collection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_Saga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_GameTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_Edition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_Developers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_Publishers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGeneralFeaturesObjectsValue_GameRating = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    GameSpecificationsObjectsValue_Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameSpecificationsObjectsValue_AudioLanguages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameSpecificationsObjectsValue_SubtitleLanguages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameSpecificationsObjectsValue_ScreenLanguages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameSpecificationsObjectsValue_MaximumNumberOfOfflinePlayers = table.Column<int>(type: "int", nullable: true),
                    GameSpecificationsObjectsValue_MaximumNumberOfOnlinePlayers = table.Column<int>(type: "int", nullable: true),
                    GameSpecificationsObjectsValue_FileSize = table.Column<int>(type: "int", nullable: true),
                    GameSpecificationsObjectsValue_ItsMultiplayer = table.Column<bool>(type: "bit", nullable: true),
                    GameSpecificationsObjectsValue_ItsOnline = table.Column<bool>(type: "bit", nullable: true),
                    GameSpecificationsObjectsValue_ItsOffline = table.Column<bool>(type: "bit", nullable: true),
                    GameSpecificationsObjectsValue_RequiresPeripheral = table.Column<bool>(type: "bit", nullable: true),
                    GameRequirementsObjectsValue_MinimumRAMRequirement = table.Column<int>(type: "int", nullable: true),
                    GameRequirementsObjectsValue_MinimumOperatingSystemsRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameRequirementsObjectsValue_MinimumGraphicsProcessorsRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameRequirementsObjectsValue_MinimumProcessorsRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmartphoneFeatureObjectValue_CellNetworkTechnology = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SmartphoneFeatureObjectValue_VirtualAssistant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SmartphoneFeatureObjectValue_ManufacturerPartNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SmartphoneFeatureObjectValue_Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SmartphoneDisplayObjectValue_DisplayType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SmartphoneDisplayObjectValue_DisplaySizeInche = table.Column<double>(type: "float", nullable: true),
                    SmartphoneDisplayObjectValue_DisplayResolution = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmartphoneDisplayObjectValue_DisplayProtection = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SmartphoneMemoryObjectValue_StorageGB = table.Column<int>(type: "int", nullable: true),
                    SmartphoneMemoryObjectValue_RAMGB = table.Column<int>(type: "int", nullable: true),
                    SmartphoneCameraObjectValue_MainCameraSpec = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmartphoneCameraObjectValue_MainCameraFeature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SmartphoneCameraObjectValue_SelfieCameraSpec = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmartphoneCameraObjectValue_SelfieCameraFeature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SmartphonePlatformObjectValue_OperatingSystem = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmartphonePlatformObjectValue_Chipset = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SmartphonePlatformObjectValue_GPU = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmartphonePlatformObjectValue_CPU = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmartphoneBatteryObjectValue_BatteryType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmartphoneBatteryObjectValue_BatteryCapacitymAh = table.Column<int>(type: "int", nullable: true),
                    SmartphoneBatteryObjectValue_IsBatteryRemovable = table.Column<bool>(type: "bit", nullable: true),
                    SmartphoneDimensionsObjectValue_HeightInche = table.Column<double>(type: "float", nullable: true),
                    SmartphoneDimensionsObjectValue_WidthInche = table.Column<double>(type: "float", nullable: true),
                    SmartphoneDimensionsObjectValue_ThicknessInche = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductReviewId",
                        column: x => x.ProductReviewId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryImage", "CategoryName" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1569040029205-a03a8b455808?q=80&w=1546&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Smartphones" },
                    { 2, "https://images.unsplash.com/photo-1537832816519-689ad163238b?q=80&w=1718&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Fashion" },
                    { 3, "https://images.unsplash.com/photo-1509198397868-475647b2a1e5?q=80&w=1547&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Games" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "SmartphoneBatteryObjectValue_BatteryCapacitymAh", "SmartphoneBatteryObjectValue_BatteryType", "SmartphoneBatteryObjectValue_IsBatteryRemovable", "SmartphoneCameraObjectValue_MainCameraFeature", "SmartphoneCameraObjectValue_MainCameraSpec", "SmartphoneCameraObjectValue_SelfieCameraFeature", "SmartphoneCameraObjectValue_SelfieCameraSpec", "SmartphoneDimensionsObjectValue_HeightInche", "SmartphoneDimensionsObjectValue_ThicknessInche", "SmartphoneDimensionsObjectValue_WidthInche", "SmartphoneDisplayObjectValue_DisplayProtection", "SmartphoneDisplayObjectValue_DisplayResolution", "SmartphoneDisplayObjectValue_DisplaySizeInche", "SmartphoneDisplayObjectValue_DisplayType", "SmartphoneFeatureObjectValue_CellNetworkTechnology", "SmartphoneFeatureObjectValue_Color", "SmartphoneFeatureObjectValue_ManufacturerPartNumber", "SmartphoneFeatureObjectValue_VirtualAssistant", "SmartphoneMemoryObjectValue_RAMGB", "SmartphoneMemoryObjectValue_StorageGB", "SmartphonePlatformObjectValue_CPU", "SmartphonePlatformObjectValue_Chipset", "SmartphonePlatformObjectValue_GPU", "SmartphonePlatformObjectValue_OperatingSystem", "CategoryId", "Description", "Discriminator", "Name", "Stock", "ProductDataObjectValue_ReleaseMonth", "ProductDataObjectValue_ReleaseYear", "ProductFlagsObjectValue_IsBestSeller", "ProductFlagsObjectValue_IsDailyOffer", "ProductFlagsObjectValue_IsFavorite", "ProductImageObjectValue_ImageFirst", "ProductImageObjectValue_ImageSecond", "ProductImageObjectValue_ImageThird", "ProductImageObjectValue_MainImage", "ProductPriceObjectValue_HistoryPrice", "ProductPriceObjectValue_Price", "ProductSpecificationsObjectValue_ProductBrand", "ProductSpecificationsObjectValue_ProductLine", "ProductSpecificationsObjectValue_ProductModel", "ProductSpecificationsObjectValue_ProductType", "ProductSpecificationsObjectValue_ProductWeight", "ProductWarrantyObjectValue_WarrantyInformation", "ProductWarrantyObjectValue_WarrantyLength" },
                values: new object[] { 1, 5000, "Li-Ion", false, "(Quad) 200 MP + 10 MP + 10 MP + 12 MP", "200 MPx", "LED flash, auto-HDR, panorama", "12 MP", 6.4299999999999997, 0.34999999999999998, 3.0699999999999998, "Corning Gorilla Glass Victus 2", "1440 x 3088 pixels", 6.7999999999999998, "Dynamic AMOLED 2X", "WCDMA (UMTS) / GSM / 5G", "Phantom Black", "SM-S918UZKFXAA", "Samsung Bixby,Alexa,Google Assistant", 16, 512, "Octa-core", "Qualcomm SM8550-AC Snapdragon 8 Gen 2", "Adreno 740", "Android", 1, "Introducing Galaxy S23 Ultra - a smartphone that takes innovation to new heights. With its crystal-clear camera resolution and stunning Night Mode powered by Nightography, you can capture and share unforgettable moments, regardless of lighting conditions. Powered by the fastest Snapdragon processor, multitasking and intense gaming become seamless. Enjoy the convenience of a built-in S Pen, allowing you to write, sketch, edit, and share from anywhere. All of this on a large display designed for gaming, streaming, creating, and more. Elevate your everyday experience with a device that's truly extraordinary and share the epic with Galaxy S23 Ultra.", "Smartphone", "Galaxy S23 Ultra 512GB Unlocked - Black", 20, "June", "2023", false, true, true, "https://http2.mlstatic.com/D_NQ_NP_945544-MLU70401529414_072023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_808604-MLU70400221716_072023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_827555-MLU70400783806_072023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_856672-MLU70401529412_072023-O.webp", 6199.99m, 4479.99m, "Samsung", "Galaxy S", "S23 Ultra", "Smartphone", "233 g", "30-Day Limited Warranty", "1-year warranty" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ShoesDesignObjectValue_AdjustmentTypes", "ShoesDesignObjectValue_TypeOfPipe", "ShoesGeneralFeaturesObjectValue_Age", "ShoesGeneralFeaturesObjectValue_Color", "ShoesGeneralFeaturesObjectValue_Gender", "ShoesGeneralFeaturesObjectValue_Version", "ShoesMaterialsObjectValue_InteriorMaterials", "ShoesMaterialsObjectValue_MaterialsFromAbroad", "ShoesMaterialsObjectValue_SoleMaterials", "ShoesSpecificationsObjectValue_RecommendedSports", "ShoesSpecificationsObjectValue_Size", "ShoesSpecificationsObjectValue_Style", "CategoryId", "Description", "Discriminator", "Name", "Stock", "ProductDataObjectValue_ReleaseMonth", "ProductDataObjectValue_ReleaseYear", "ProductFlagsObjectValue_IsBestSeller", "ProductFlagsObjectValue_IsDailyOffer", "ProductFlagsObjectValue_IsFavorite", "ProductImageObjectValue_ImageFirst", "ProductImageObjectValue_ImageSecond", "ProductImageObjectValue_ImageThird", "ProductImageObjectValue_MainImage", "ProductPriceObjectValue_HistoryPrice", "ProductPriceObjectValue_Price", "ProductSpecificationsObjectValue_ProductBrand", "ProductSpecificationsObjectValue_ProductLine", "ProductSpecificationsObjectValue_ProductModel", "ProductSpecificationsObjectValue_ProductType", "ProductSpecificationsObjectValue_ProductWeight", "ProductWarrantyObjectValue_WarrantyInformation", "ProductWarrantyObjectValue_WarrantyLength" },
                values: new object[] { 2, "Shoelaces", "", "Adult", "Black", "Woman", "two", "", "", "", "skateboarding/casual", "7.5", "Urban", 2, "Buoyed to the comfort you've come to trust, the Air Max Excee meets the needs of your 9 to 5 while keeping your outfit on-point with rich textures. These sneakers deliver just what you're looking for—soft cushioning that's easy to style.\r\n\r\n", "Shoes", "Nike Air Max Excee", 15, "June", "2023", false, false, true, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f0f9838c-a13f-4a16-9d6a-045b8bcd4663/air-max-excee-womens-shoes-jKsgMj.png", "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/33f14890-9ba3-4ca0-90b6-f3a099620840/air-max-excee-womens-shoes-jKsgMj.png", "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/14b801db-a5c6-417b-8fd3-2a630291e3d9/air-max-excee-womens-shoes-jKsgMj.png", "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/4ff2fe4a-4f74-4189-82f0-3ea780f9389d/air-max-excee-womens-shoes-jKsgMj.png", 0.0m, 95.99m, "Nike", "SB", "DM3493", "Shoes", "368,5 g", "45-Day Limited Warranty", "1-year warranty" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "TshirtMainFeaturesObectsValue_Age", "TshirtMainFeaturesObectsValue_FabricDesign", "TshirtMainFeaturesObectsValue_Gender", "TshirtMainFeaturesObectsValue_Size", "TshirtMainFeaturesObectsValue_TypeOfClothing", "TshirtOtherFeaturesObectsValue_Composition", "TshirtOtherFeaturesObectsValue_ItsSporty", "TshirtOtherFeaturesObectsValue_KindOfFabric", "TshirtOtherFeaturesObectsValue_MainMaterial", "TshirtOtherFeaturesObectsValue_RecommendedUses", "TshirtOtherFeaturesObectsValue_SleeveType", "TshirtOtherFeaturesObectsValue_TypeOfCollar", "TshirtOtherFeaturesObectsValue_UnitsPerKit", "TshirtOtherFeaturesObectsValue_WithRecycledMaterials", "CategoryId", "Description", "Discriminator", "Name", "Stock", "ProductDataObjectValue_ReleaseMonth", "ProductDataObjectValue_ReleaseYear", "ProductFlagsObjectValue_IsBestSeller", "ProductFlagsObjectValue_IsDailyOffer", "ProductFlagsObjectValue_IsFavorite", "ProductImageObjectValue_ImageFirst", "ProductImageObjectValue_ImageSecond", "ProductImageObjectValue_ImageThird", "ProductImageObjectValue_MainImage", "ProductPriceObjectValue_HistoryPrice", "ProductPriceObjectValue_Price", "ProductSpecificationsObjectValue_ProductBrand", "ProductSpecificationsObjectValue_ProductLine", "ProductSpecificationsObjectValue_ProductModel", "ProductSpecificationsObjectValue_ProductType", "ProductSpecificationsObjectValue_ProductWeight", "ProductWarrantyObjectValue_WarrantyInformation", "ProductWarrantyObjectValue_WarrantyLength" },
                values: new object[] { 3, "Adult", "Straight", "Woman", "S", "T-shirt", "Polyester", false, "Dry", "Polyester", "Casual", "Like", "Round neck", 1, false, 2, "The Nike Classic Swoosh Futura medium support women's workout top offers long-lasting comfort during training with sweat-wicking fabric and a compression fit.", "Tshirt", "Top Nike Swoosh Woman", 5, "June", "2023", true, false, true, "https://imgnike-a.akamaihd.net/768x768/002897IDA1.jpg", "https://imgnike-a.akamaihd.net/768x768/002897IDA4.jpg", "https://imgnike-a.akamaihd.net/768x768/002897IDA5.jpg", "https://imgnike-a.akamaihd.net/768x768/002897ID.jpg", 0.0m, 16.99m, "Nike", "", "T-Shirt", "T-Shirt", "200 g", "15-Day Limited Warranty", "1-year warranty" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discriminator", "Name", "Stock", "ProductDataObjectValue_ReleaseMonth", "ProductDataObjectValue_ReleaseYear", "ProductFlagsObjectValue_IsBestSeller", "ProductFlagsObjectValue_IsDailyOffer", "ProductFlagsObjectValue_IsFavorite", "ProductImageObjectValue_ImageFirst", "ProductImageObjectValue_ImageSecond", "ProductImageObjectValue_ImageThird", "ProductImageObjectValue_MainImage", "ProductPriceObjectValue_HistoryPrice", "ProductPriceObjectValue_Price", "ProductSpecificationsObjectValue_ProductBrand", "ProductSpecificationsObjectValue_ProductLine", "ProductSpecificationsObjectValue_ProductModel", "ProductSpecificationsObjectValue_ProductType", "ProductSpecificationsObjectValue_ProductWeight", "ProductWarrantyObjectValue_WarrantyInformation", "ProductWarrantyObjectValue_WarrantyLength", "GameGeneralFeaturesObjectsValue_Collection", "GameGeneralFeaturesObjectsValue_Developers", "GameGeneralFeaturesObjectsValue_Edition", "GameGeneralFeaturesObjectsValue_GameRating", "GameGeneralFeaturesObjectsValue_GameTitle", "GameGeneralFeaturesObjectsValue_Genres", "GameGeneralFeaturesObjectsValue_Platform", "GameGeneralFeaturesObjectsValue_Publishers", "GameGeneralFeaturesObjectsValue_Saga", "GameRequirementsObjectsValue_MinimumGraphicsProcessorsRequired", "GameRequirementsObjectsValue_MinimumOperatingSystemsRequired", "GameRequirementsObjectsValue_MinimumProcessorsRequired", "GameRequirementsObjectsValue_MinimumRAMRequirement", "GameSpecificationsObjectsValue_AudioLanguages", "GameSpecificationsObjectsValue_FileSize", "GameSpecificationsObjectsValue_Format", "GameSpecificationsObjectsValue_ItsMultiplayer", "GameSpecificationsObjectsValue_ItsOffline", "GameSpecificationsObjectsValue_ItsOnline", "GameSpecificationsObjectsValue_MaximumNumberOfOfflinePlayers", "GameSpecificationsObjectsValue_MaximumNumberOfOnlinePlayers", "GameSpecificationsObjectsValue_RequiresPeripheral", "GameSpecificationsObjectsValue_ScreenLanguages", "GameSpecificationsObjectsValue_SubtitleLanguages" },
                values: new object[] { 4, 3, "With this Spider-Man game you will enjoy hours of fun and new challenges that will allow you to improve as a player.", "Game", "Marvel's Spider-Man: Miles Morales Standard Edition Sony PS5 Physical", 10, "June", "2023", true, false, false, "https://http2.mlstatic.com/D_NQ_NP_717296-MLA44963321732_022021-O.webp", "https://http2.mlstatic.com/D_NQ_NP_902181-MLA44963396568_022021-O.webp", "https://http2.mlstatic.com/D_NQ_NP_952087-MLU69953465194_062023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_739971-MLA44963396567_022021-O.webp", 0.0m, 30.99m, "Sony", "PS5", "Sony", "Video game", "100 g", "30-Day Limited Warranty", "1-year warranty", "Spider man", "Insomniac Games", "Standard Edition", "T", "Marvel's Spider-Man: Miles Morales", "Action", "PS5", "Sony", "30-Day Limited Warranty", "V", "PS5", "Ps5", 60, "English", 60, "Physical", false, true, false, 1, 1, false, "English, Portuguese", "English, Portuguese" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "Image", "ProductReviewId", "Rating", "ReviewDate" },
                values: new object[,]
                {
                    { 1, "The quality of the photos is incredible.", "https://http2.mlstatic.com/D_NQ_NP_637616-MLA70484274053_072023-O.webp", 1, 5, new DateTime(2023, 12, 1, 22, 14, 17, 141, DateTimeKind.Local).AddTicks(2222) },
                    { 2, "Very good purchase, it arrived very quickly and it arrived like a totally new phone, it only has very slight details on the sides.", "https://m.media-amazon.com/images/I/71a4vqXqxbL._SY256.jpg", 1, 5, new DateTime(2023, 12, 1, 22, 14, 17, 141, DateTimeKind.Local).AddTicks(2236) },
                    { 3, "Good!", "https://http2.mlstatic.com/D_NQ_NP_2X_743184-MLA69501979268_052023-F.webp", 1, 4, new DateTime(2023, 12, 1, 22, 14, 17, 141, DateTimeKind.Local).AddTicks(2237) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductReviewId",
                table: "Reviews",
                column: "ProductReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
