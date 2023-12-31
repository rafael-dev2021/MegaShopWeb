﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra_Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultPaymentMethod = table.Column<int>(type: "int", nullable: false),
                    IsSubscribedToNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EPaymentMethod = table.Column<int>(type: "int", nullable: false),
                    EPaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: true),
                    CardHolderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Reference = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBillingAddress = table.Column<bool>(type: "bit", nullable: false),
                    UserGenericId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_AspNetUsers_UserGenericId",
                        column: x => x.UserGenericId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    ProductSpecificationsObjectValue_ProductModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    SmartphoneCameraObjectValue_SelfieCameraFeature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SmartphonePlatformObjectValue_OperatingSystem = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmartphonePlatformObjectValue_Chipset = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SmartphonePlatformObjectValue_GPU = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SmartphonePlatformObjectValue_CPU = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
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
                    { 1, "https://i5.walmartimages.com/seo/Straight-Talk-Apple-iPhone-12-64GB-Black-Prepaid-Smartphone-Locked-to-Straight-Talk_66b2853b-6cb5-4f20-b73a-b60b39b6de44.6b3bf83a920058a47342318925f1dc2b.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", "Smartphones" },
                    { 2, "https://i5.walmartimages.com/seo/Reebok-Women-s-Flight-Jogger-with-Cargo-Pockets_eefde8e0-c787-48fc-962e-2d2d406391a1.70bc369116e0b1954b5eee14c1a67ea7.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", "Fashion" },
                    { 3, "https://i5.walmartimages.com/seo/Xbox-Series-X-Video-Game-Console-Black_9f8c06f5-7953-426d-9b68-ab914839cef4.5f15be430800ce4d7c3bb5694d4ab798.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", "Games" },
                    { 4, "https://i5.walmartimages.com/seo/Carote-Nonstick-Pots-and-Pans-Set-10-Pcs-Granite-Stone-Kitchen-Cookware-Sets-White_efe69ee7-6273-4cbe-a436-149b7b1d0d0c.a2320ff6519d540c3df326c48fdef207.png?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF", "Kitchen" },
                    { 5, "https://i5.walmartimages.com/seo/Friendship-Bracelet-Making-Kit-Girls-DIY-Craft-Kits-Toys-Cool-Arts-Crafts-Teen-Travel-Activity-Set-Gifts-Age-6-7-8-9-10-11-12-Year-Old_1c074238-f765-4bc9-bcd4-6aec3c63e831.61da6ea6dec87564dbe3452ae6d55039.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", "Kids" },
                    { 6, "https://i5.walmartimages.com/seo/Acer-Nitro-31-5-1500R-Curved-Full-HD-1920-x-1080-Gaming-Monitor-Black-ED320QR-S3biipx_026e53ed-7591-4f39-afb1-d5575a7fc06a.fae36db73738179d935b7d5e64a5be51.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", "Electronic" },
                    { 7, "https://i5.walmartimages.com/seo/Intex-Corner-Sofa_b6271dd9-4704-436a-aa35-36293fa7482c_1.887862bad366185f36f3793d387c450e.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "SmartphoneBatteryObjectValue_BatteryCapacitymAh", "SmartphoneBatteryObjectValue_BatteryType", "SmartphoneBatteryObjectValue_IsBatteryRemovable", "SmartphoneCameraObjectValue_MainCameraFeature", "SmartphoneCameraObjectValue_MainCameraSpec", "SmartphoneCameraObjectValue_SelfieCameraFeature", "SmartphoneCameraObjectValue_SelfieCameraSpec", "SmartphoneDimensionsObjectValue_HeightInche", "SmartphoneDimensionsObjectValue_ThicknessInche", "SmartphoneDimensionsObjectValue_WidthInche", "SmartphoneDisplayObjectValue_DisplayProtection", "SmartphoneDisplayObjectValue_DisplayResolution", "SmartphoneDisplayObjectValue_DisplaySizeInche", "SmartphoneDisplayObjectValue_DisplayType", "SmartphoneFeatureObjectValue_CellNetworkTechnology", "SmartphoneFeatureObjectValue_Color", "SmartphoneFeatureObjectValue_ManufacturerPartNumber", "SmartphoneFeatureObjectValue_VirtualAssistant", "SmartphoneMemoryObjectValue_RAMGB", "SmartphoneMemoryObjectValue_StorageGB", "SmartphonePlatformObjectValue_CPU", "SmartphonePlatformObjectValue_Chipset", "SmartphonePlatformObjectValue_GPU", "SmartphonePlatformObjectValue_OperatingSystem", "CategoryId", "Description", "Discriminator", "Name", "Stock", "ProductDataObjectValue_ReleaseMonth", "ProductDataObjectValue_ReleaseYear", "ProductFlagsObjectValue_IsBestSeller", "ProductFlagsObjectValue_IsDailyOffer", "ProductFlagsObjectValue_IsFavorite", "ProductImageObjectValue_ImageFirst", "ProductImageObjectValue_ImageSecond", "ProductImageObjectValue_ImageThird", "ProductImageObjectValue_MainImage", "ProductPriceObjectValue_HistoryPrice", "ProductPriceObjectValue_Price", "ProductSpecificationsObjectValue_ProductBrand", "ProductSpecificationsObjectValue_ProductLine", "ProductSpecificationsObjectValue_ProductModel", "ProductSpecificationsObjectValue_ProductType", "ProductSpecificationsObjectValue_ProductWeight", "ProductWarrantyObjectValue_WarrantyInformation", "ProductWarrantyObjectValue_WarrantyLength" },
                values: new object[,]
                {
                    { 1, 5000, "Li-Ion", false, "(Quad) 200 MP + 10 MP + 10 MP + 12 MP", "200 Mpx", "LED flash, auto-HDR, panorama", "12 Mpx", 163.40000000000001, 8.9000000000000004, 78.099999999999994, "Corning Gorilla Glass Victus 2", "1440 px x 3088 px", 6.7999999999999998, "Dynamic AMOLED 2X 120 Hz", "WCDMA (UMTS) / GSM / 5G", "Phantom Black", "SM-S918UZKFXAA", "Samsung Bixby,Alexa,Google Assistant", 12, 512, "Octa-core", "Qualcomm SM8550-AC Snapdragon 8 Gen 2", "Adreno 740", "Android", 1, "Maximum security so that only you can access your team. You can choose between the fingerprint sensor to activate your phone with a tap, or facial recognition that allows you to unlock up to 30% faster.", "Smartphone", "Samsung Galaxy S23 Ultra 512GB Unlocked - Black", 20, "June", "2023", false, true, true, "https://http2.mlstatic.com/D_NQ_NP_945544-MLU70401529414_072023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_808604-MLU70400221716_072023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_827555-MLU70400783806_072023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_856672-MLU70401529412_072023-O.webp", 2299.99m, 2179.99m, "Samsung", "Galaxy S", "S23 Ultra", "Smartphone", "233 g", "30-Day Limited Warranty", "1-year warranty" },
                    { 2, 5000, "Lithium Ion", false, "200 Mpx/12 Mpx/10 Mpx/10 Mpx", "200 Mpx", "LED flash, auto-HDR, panorama", "12 Mpx", 163.40000000000001, 8.9000000000000004, 78.099999999999994, "Corning Gorilla Glass Victus 2", "1440 px x 3088 px", 6.7999999999999998, "Dynamic AMOLED 2X", "WCDMA (UMTS) / GSM / 5G", "Violet", "SM-B518UZKFX22", "Samsung Bixby,Alexa,Google Assistant", 8, 258, "Octa-Core of up to 3.36GHz", "Qualcomm SM8550-AC Snapdragon 8 Gen 2", "Adreno 740", "Android", 1, "Maximum security so that only you can access your team. You can choose between the fingerprint sensor to activate your phone with a tap, or facial recognition that allows you to unlock up to 30% faster.", "Smartphone", "Samsung Galaxy S23 Ultra 256GB - Violet", 25, "August", "2022", false, true, true, "https://http2.mlstatic.com/D_NQ_NP_690989-MLU72932986551_112023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_612226-MLU72932986555_112023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_683459-MLU72932986549_112023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_683947-MLU73106437489_112023-O.webp", 2199.99m, 1624.99m, "Samsung", "Galaxy S", "S23 Ultra", "Smartphone", "235 g", "30-Day Limited Warranty", "1-year warranty" },
                    { 3, 5000, "Lithium Ion", false, "48 Mpx/12 Mpx/12 Mpx", "48 Mpx", "Photonic engine, Deep fusion, Smart HDR 4, Portrait mode, Portrait lighting with six effects,", "12 Mpx", 160.90000000000001, 7.7999999999999998, 77.799999999999997, "Corning Gorilla Glass Victus 2", "2556 px x 1179 px", 6.0999999999999996, "Super Retina XDR", "WCDMA (UMTS) / GSM / 5G", "Titanium Blue", "AA-12SF7832SD301EW3", "Apple Watch,HomePod,Siri Assistant", 8, 512, "Chip A16 Bionic", "Apple A17 Pro", "5 cores", "iOS", 1, "FORGED FROM TITANIUM — iPhone 15 Pro features a rugged, lightweight design made from aerospace-grade titanium. On the back, textured matte glass and, on the front, Ceramic Shield, more resistant than any smartphone glass. It's also tough against splashes, water, and dust.", "Smartphone", "Apple iPhone 15 Pro (512 GB) - Titanium Blue", 15, "Februery", "2023", false, true, false, "https://http2.mlstatic.com/D_NQ_NP_918178-MLA71783088444_092023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_829742-MLA71783365702_092023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_715495-MLA71783365704_092023-O.webps", "https://http2.mlstatic.com/D_NQ_NP_918178-MLA71783088444_092023-O.webp", 2199.99m, 2035.99m, "Apple", "iPhone", "iPhone 15 Pro", "Smartphone", "235 g", "30-Day Limited Warranty", "1-year warranty" },
                    { 4, 5000, "Lithium Ion", false, "48 Mpx/12 Mpx/12 Mpx", "48 Mpx", "Photonic engine, Deep fusion, Smart HDR 4, Portrait mode, Portrait lighting with six effects,", "12 Mpx", 160.90000000000001, 7.7999999999999998, 77.799999999999997, "Corning Gorilla Glass Victus 2", "2556 px x 1179 px", 6.0999999999999996, "Super Retina XDR", "WCDMA (UMTS) / GSM / 5G", "Titanium White", "AA-12VD783HR230SW19", "Apple Watch,HomePod,Siri Assistant", 8, 128, "Chip A16 Bionic", "Apple A17 Pro", "5 cores", "iOS", 1, "FORGED FROM TITANIUM — iPhone 15 Pro features a rugged, lightweight design made from aerospace-grade titanium. On the back, textured matte glass and, on the front, Ceramic Shield, more resistant than any smartphone glass. It's also tough against splashes, water, and dust.", "Smartphone", "Apple iPhone 15 Pro (128 GB) - Titanium White", 10, "March", "2023", false, true, true, "https://http2.mlstatic.com/D_NQ_NP_812116-MLA71783168214_092023E-O.webp", "https://http2.mlstatic.com/D_NQ_NP_658271-MLA71782871766_092023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_998898-MLA71782901894_092023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_812116-MLA71783168214_092023E-O.webp", 1799.99m, 1624.99m, "Apple", "iPhone", "iPhone 15 Pro", "Smartphone", "235 g", "30-Day Limited Warranty", "1-year warranty" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discriminator", "Name", "Stock", "ProductDataObjectValue_ReleaseMonth", "ProductDataObjectValue_ReleaseYear", "ProductFlagsObjectValue_IsBestSeller", "ProductFlagsObjectValue_IsDailyOffer", "ProductFlagsObjectValue_IsFavorite", "ProductImageObjectValue_ImageFirst", "ProductImageObjectValue_ImageSecond", "ProductImageObjectValue_ImageThird", "ProductImageObjectValue_MainImage", "ProductPriceObjectValue_HistoryPrice", "ProductPriceObjectValue_Price", "ProductSpecificationsObjectValue_ProductBrand", "ProductSpecificationsObjectValue_ProductLine", "ProductSpecificationsObjectValue_ProductModel", "ProductSpecificationsObjectValue_ProductType", "ProductSpecificationsObjectValue_ProductWeight", "ProductWarrantyObjectValue_WarrantyInformation", "ProductWarrantyObjectValue_WarrantyLength", "GameGeneralFeaturesObjectsValue_Collection", "GameGeneralFeaturesObjectsValue_Developers", "GameGeneralFeaturesObjectsValue_Edition", "GameGeneralFeaturesObjectsValue_GameRating", "GameGeneralFeaturesObjectsValue_GameTitle", "GameGeneralFeaturesObjectsValue_Genres", "GameGeneralFeaturesObjectsValue_Platform", "GameGeneralFeaturesObjectsValue_Publishers", "GameGeneralFeaturesObjectsValue_Saga", "GameRequirementsObjectsValue_MinimumGraphicsProcessorsRequired", "GameRequirementsObjectsValue_MinimumOperatingSystemsRequired", "GameRequirementsObjectsValue_MinimumProcessorsRequired", "GameRequirementsObjectsValue_MinimumRAMRequirement", "GameSpecificationsObjectsValue_AudioLanguages", "GameSpecificationsObjectsValue_FileSize", "GameSpecificationsObjectsValue_Format", "GameSpecificationsObjectsValue_ItsMultiplayer", "GameSpecificationsObjectsValue_ItsOffline", "GameSpecificationsObjectsValue_ItsOnline", "GameSpecificationsObjectsValue_MaximumNumberOfOfflinePlayers", "GameSpecificationsObjectsValue_MaximumNumberOfOnlinePlayers", "GameSpecificationsObjectsValue_RequiresPeripheral", "GameSpecificationsObjectsValue_ScreenLanguages", "GameSpecificationsObjectsValue_SubtitleLanguages" },
                values: new object[,]
                {
                    { 5, 3, "With this Spider-Man game you will enjoy hours of fun and new challenges that will allow you to improve as a player.", "Game", "Marvel's Spider-Man: Miles Morales Standard Edition Sony PS5 Physical", 10, "June", "2023", true, false, true, "https://http2.mlstatic.com/D_NQ_NP_717296-MLA44963321732_022021-O.webp", "https://http2.mlstatic.com/D_NQ_NP_902181-MLA44963396568_022021-O.webp", "https://http2.mlstatic.com/D_NQ_NP_952087-MLU69953465194_062023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_739971-MLA44963396567_022021-O.webp", 0.0m, 30.99m, "Sony", "PS5", "Sony", "Video game", "100 g", "30-Day Limited Warranty", "1-year warranty", "Spider man", "Insomniac Games", "Standard Edition", "T", "Marvel's Spider-Man: Miles Morales", "Action", "PS5", "Sony", "30-Day Limited Warranty", "V", "PS5", "Ps5", 60, "English", 60, "Physical", false, true, false, 1, 1, false, "English, Portuguese", "English, Portuguese" },
                    { 6, 3, "With this God of War game you will enjoy hours of fun and new challenges that will allow you to improve as a player. You will be able to share each game with people from all over the world as you can connect online.", "Game", "God of War Ragnarök Standard Edition Sony PS5 Physical", 15, "July", "2022", true, false, true, "https://http2.mlstatic.com/D_NQ_NP_924074-MLU69483138400_052023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_662378-MLU69483138404_052023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_852774-MLU69482634062_052023-O.webp", "https://http2.mlstatic.com/D_NQ_NP_834716-MLU72751588558_112023-O.webp", 0.0m, 38.99m, "Sony", "PS5", "Sony", "Video game", "100 g", "30-Day Limited Warranty", "1-year warranty", "God of War", "SIE Santa Monica Studio", "Standard Edition", "M", "God of War Ragnarök", "Action", "PS5", "Sony", "30-Day Limited Warranty", "V", "PS5", "Ps5", 60, "English, Spanish, Portuguese", 91, "Physical", false, true, true, 1, 1, false, "Spanish, English, Portuguese", "Spanish, English, Portuguese" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "TshirtMainFeaturesObectsValue_Age", "TshirtMainFeaturesObectsValue_FabricDesign", "TshirtMainFeaturesObectsValue_Gender", "TshirtMainFeaturesObectsValue_Size", "TshirtMainFeaturesObectsValue_TypeOfClothing", "TshirtOtherFeaturesObectsValue_Composition", "TshirtOtherFeaturesObectsValue_ItsSporty", "TshirtOtherFeaturesObectsValue_KindOfFabric", "TshirtOtherFeaturesObectsValue_MainMaterial", "TshirtOtherFeaturesObectsValue_RecommendedUses", "TshirtOtherFeaturesObectsValue_SleeveType", "TshirtOtherFeaturesObectsValue_TypeOfCollar", "TshirtOtherFeaturesObectsValue_UnitsPerKit", "TshirtOtherFeaturesObectsValue_WithRecycledMaterials", "CategoryId", "Description", "Discriminator", "Name", "Stock", "ProductDataObjectValue_ReleaseMonth", "ProductDataObjectValue_ReleaseYear", "ProductFlagsObjectValue_IsBestSeller", "ProductFlagsObjectValue_IsDailyOffer", "ProductFlagsObjectValue_IsFavorite", "ProductImageObjectValue_ImageFirst", "ProductImageObjectValue_ImageSecond", "ProductImageObjectValue_ImageThird", "ProductImageObjectValue_MainImage", "ProductPriceObjectValue_HistoryPrice", "ProductPriceObjectValue_Price", "ProductSpecificationsObjectValue_ProductBrand", "ProductSpecificationsObjectValue_ProductLine", "ProductSpecificationsObjectValue_ProductModel", "ProductSpecificationsObjectValue_ProductType", "ProductSpecificationsObjectValue_ProductWeight", "ProductWarrantyObjectValue_WarrantyInformation", "ProductWarrantyObjectValue_WarrantyLength" },
                values: new object[,]
                {
                    { 7, "Adult", "Straight", "Woman", "S", "T-shirt", "Polyester", false, "Dry", "Polyester", "Casual", "Like", "Round neck", 1, false, 2, "The Nike Classic Swoosh Futura medium support women's workout top offers long-lasting comfort during training with sweat-wicking fabric and a compression fit.", "Tshirt", "Top Nike Swoosh Woman", 5, "June", "2023", true, false, true, "https://imgnike-a.akamaihd.net/768x768/002897IDA1.jpg", "https://imgnike-a.akamaihd.net/768x768/002897IDA4.jpg", "https://imgnike-a.akamaihd.net/768x768/002897IDA5.jpg", "https://imgnike-a.akamaihd.net/768x768/002897ID.jpg", 0.0m, 16.99m, "Nike", "", "Nike T-Shirt", "T-Shirt", "200 g", "15-Day Limited Warranty", "1-year warranty" },
                    { 8, "Adult", "Straight", "Woman", "XS", "T-shirt", "Polyester", true, "Dry", "Polyester", "Casual", "Like", "Round neck", 1, false, 2, "Fresh and full of life, this Adicolor Firebird track jacket celebrates the power and authenticity of adidas' legendary DNA.", "Tshirt", "Adicolor classics firebird track jacket", 8, "March", "2023", false, true, false, "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/3cae025992434e889496afcd002c97ae_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_42_detail.jpg", "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/c6f0e6def4bd4eefa0bfafcd002c7094_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_21_model.jpg", "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a915172e29f24ce4b34bafcd002c78dc_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_23_hover_model.jpg", "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/a5757a66a549439cbac6afcd002ca57f_9366/Adicolor_Classics_Firebird_Track_Jacket_Black_IL8764_01_laydown.jpg", 80.0m, 64.99m, "Adidas", "", "JACKET Adidas", "T-Shirt", "350 g", "15-Day Limited Warranty", "1-year warranty" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ShoesDesignObjectValue_AdjustmentTypes", "ShoesDesignObjectValue_TypeOfPipe", "ShoesGeneralFeaturesObjectValue_Age", "ShoesGeneralFeaturesObjectValue_Color", "ShoesGeneralFeaturesObjectValue_Gender", "ShoesGeneralFeaturesObjectValue_Version", "ShoesMaterialsObjectValue_InteriorMaterials", "ShoesMaterialsObjectValue_MaterialsFromAbroad", "ShoesMaterialsObjectValue_SoleMaterials", "ShoesSpecificationsObjectValue_RecommendedSports", "ShoesSpecificationsObjectValue_Size", "ShoesSpecificationsObjectValue_Style", "CategoryId", "Description", "Discriminator", "Name", "Stock", "ProductDataObjectValue_ReleaseMonth", "ProductDataObjectValue_ReleaseYear", "ProductFlagsObjectValue_IsBestSeller", "ProductFlagsObjectValue_IsDailyOffer", "ProductFlagsObjectValue_IsFavorite", "ProductImageObjectValue_ImageFirst", "ProductImageObjectValue_ImageSecond", "ProductImageObjectValue_ImageThird", "ProductImageObjectValue_MainImage", "ProductPriceObjectValue_HistoryPrice", "ProductPriceObjectValue_Price", "ProductSpecificationsObjectValue_ProductBrand", "ProductSpecificationsObjectValue_ProductLine", "ProductSpecificationsObjectValue_ProductModel", "ProductSpecificationsObjectValue_ProductType", "ProductSpecificationsObjectValue_ProductWeight", "ProductWarrantyObjectValue_WarrantyInformation", "ProductWarrantyObjectValue_WarrantyLength" },
                values: new object[,]
                {
                    { 9, "Shoelaces", "Middle pipe", "Adult", "Pink/Gold and Black", "Woman", "two", "Cotton", "Leather", "Rubber", "skateboarding/casual", "7.5", "Urban", 2, "Buoyed to the comfort you've come to trust, the Air Max Excee meets the needs of your 9 to 5 while keeping your outfit on-point with rich textures. These sneakers deliver just what you're looking for—soft cushioning that's easy to style.", "Shoes", "Nike Streakfly", 15, "June", "2023", false, true, true, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/97fb810e-5803-43f5-98ac-67c8763deb15/streakfly-road-racing-shoes-8rTxtR.png", "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/6d25c69b-b08b-4cc7-b97d-8384e196951f/streakfly-road-racing-shoes-8rTxtR.png", "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/54e264aa-a85f-4152-b409-ed0372924d81/streakfly-road-racing-shoes-8rTxtR.png", "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/24d5a5ec-db76-4512-99a8-36231b9a9b41/streakfly-road-racing-shoes-8rTxtR.png", 95.0m, 71.99m, "Nike", "SB", "DM3493", "Shoes", "368,5 g", "45-Day Limited Warranty", "1-year warranty" },
                    { 10, "Shoelaces", "Middle pipe", "Adult", "Black", "Man", "One", "Cotton", "Leather", "Rubber", "skateboarding/casual", "7.5", "Urban", 2, "The Suede hit the scene in 1968 and has been changing the game ever since. It’s been worn by icons of every generation, and it’s stayed classic through it all. Instantly recognizable and constantly reinvented, Suede’s legacy continues to grow and be legitimized by the authentic and expressive individuals that embrace the iconic shoe. Be apart of the history of Suede.", "Shoes", "Suede Classic XXI Sneakers", 15, "October", "2022", true, false, true, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/mod02/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers", "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/mod03/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers", "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/bv/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers", "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/374915/01/sv01/fnd/PNA/fmt/png/Suede-Classic-XXI-Sneakers", 0.0m, 75.99m, "Puma", "SB", "Basketball Classic XXI sneakers", "Shoes", "368,5 g", "45-Day Limited Warranty", "1-year warranty" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "Image", "ProductReviewId", "Rating", "ReviewDate" },
                values: new object[,]
                {
                    { 1, "The quality of the photos is incredible.", "https://http2.mlstatic.com/D_NQ_NP_637616-MLA70484274053_072023-O.webp", 1, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6382) },
                    { 2, "Very good purchase, it arrived very quickly and it arrived like a totally new phone, it only has very slight details on the sides.", "https://m.media-amazon.com/images/I/71a4vqXqxbL._SY256.jpg", 1, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6398) },
                    { 3, "Good!", "https://http2.mlstatic.com/D_NQ_NP_2X_743184-MLA69501979268_052023-F.webp", 1, 4, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6399) },
                    { 4, "The best smartphone I've ever used!!! I left an iPhone 14 Pro Max, sold it, bought the S23 Ultra and still had money left. There's no comparison, with 8gb of ram you can use several applications in the background at the same time.", "https://http2.mlstatic.com/D_NQ_NP_2X_936910-MLA54765476953_032023-F.webp", 2, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6400) },
                    { 5, "Excellent, after all it is an Apple product. Worth every penny given ❤.", "https://http2.mlstatic.com/D_NQ_NP_2X_960098-MLA73264672831_122023-F.webp", 3, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6401) },
                    { 6, "The best.", "https://http2.mlstatic.com/D_NQ_NP_2X_911842-MLA73095448948_112023-F.webp", 4, 4, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6401) },
                    { 7, "New original product you can buy without fear!.", "https://http2.mlstatic.com/D_NQ_NP_2X_696237-MLA71736945652_092023-F.webp", 5, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6402) },
                    { 8, "Excellent product, came sealed.", "https://http2.mlstatic.com/D_NQ_NP_2X_918056-MLA72166744514_102023-F.webp", 5, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6403) },
                    { 9, "Perfect product.", "https://http2.mlstatic.com/D_NQ_NP_2X_661229-MLA72108620029_102023-F.webp", 6, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6404) },
                    { 10, "The best product, very good!", "https://http2.mlstatic.com/D_NQ_NP_2X_942915-MLA54965635426_042023-F.webp", 6, 4, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6405) },
                    { 11, "Pay attention to size. Nike models are smaller. The ideal is to buy 1 size larger.", "", 7, 4, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6405) },
                    { 12, "It was small on me. I want to return it. To get my refund.", "", 7, 1, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6420) },
                    { 14, "Excellent product.", "", 9, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6429) },
                    { 15, "I liked the original, it has to be laced but it's perfect.", "", 10, 5, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6430) },
                    { 16, "I'm a fan of this sneaker. One of the most beautiful on the foot, in my opinion.", "", 10, 4, new DateTime(2023, 12, 11, 0, 5, 44, 103, DateTimeKind.Local).AddTicks(6431) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_UserGenericId",
                table: "DeliveryAddress",
                column: "UserGenericId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeliveryAddress");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
