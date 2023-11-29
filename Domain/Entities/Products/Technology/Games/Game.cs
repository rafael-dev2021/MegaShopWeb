using Domain.Entities.ObjectValues.ProductsOV;
using Domain.Entities.Products.Technology.Games.ObjectsValue;

namespace Domain.Entities.Products.Technology.Games
{
    public sealed class Game : Product
    {
        public Game() { }
        public Game(int id, string? name, string? description, string? deliveryDays, int stock, int categoryId) : base(id, name, description, deliveryDays, stock, categoryId)
        {

        }
        public Game(int id, string? name, string? description, int stock, string? deliveryDays, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, GameGeneralFeaturesOV gameGeneralFeaturesObjectsValue, GameSpecificationsOV gameSpecificationsObjectsValue, GameRequirementsOV gameRequirementsObjectsValue, int categoryId)
            : base(id, name, description, stock, deliveryDays, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId)
        {
            GameGeneralFeaturesObjectsValue = gameGeneralFeaturesObjectsValue;
            GameSpecificationsObjectsValue = gameSpecificationsObjectsValue;
            GameRequirementsObjectsValue = gameRequirementsObjectsValue;

        }
        public Game(string? name, string? description, int stock, string? deliveryDays, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, GameGeneralFeaturesOV gameGeneralFeaturesObjectsValue, GameSpecificationsOV gameSpecificationsObjectsValue, GameRequirementsOV gameRequirementsObjectsValue, int categoryId)
         : base(name, description, stock, deliveryDays, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId)
        {
            GameGeneralFeaturesObjectsValue = gameGeneralFeaturesObjectsValue;
            GameSpecificationsObjectsValue = gameSpecificationsObjectsValue;
            GameRequirementsObjectsValue = gameRequirementsObjectsValue;

        }

        public void GameUpdate(string? name, string? description, int stock, string? deliveryDays, ProductDataOV productDataObjectValue, ProductFlagsOV productFlagsObjectValue, ProductImageOV productImageObjectValue, ProductPriceOV productPriceObjectValue, ProductSpecificationsOV productSpecificationsObjectValue, ProductWarrantyOV productWarrantyObjectValue, GameGeneralFeaturesOV gameGeneralFeaturesObjectsValue, GameSpecificationsOV gameSpecificationsObjectsValue, GameRequirementsOV gameRequirementsObjectsValue, int categoryId)
        {
            ProductUpdate(name, description, stock, deliveryDays, productDataObjectValue, productFlagsObjectValue, productImageObjectValue, productPriceObjectValue, productSpecificationsObjectValue, productWarrantyObjectValue, categoryId);
            GameGeneralFeaturesObjectsValue = gameGeneralFeaturesObjectsValue;
            GameSpecificationsObjectsValue = gameSpecificationsObjectsValue;
            GameRequirementsObjectsValue = gameRequirementsObjectsValue;
        }

        public GameGeneralFeaturesOV GameGeneralFeaturesObjectsValue { get; set; }
        public GameSpecificationsOV GameSpecificationsObjectsValue { get; set; }
        public GameRequirementsOV GameRequirementsObjectsValue { get; set; }
    }
}
