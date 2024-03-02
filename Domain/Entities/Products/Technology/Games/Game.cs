using Domain.Entities.Products.Technology.Games.Valuables;
using Domain.Entities.Valuables.ProductValuables;

namespace Domain.Entities.Products.Technology.Games;

public sealed class Game : Product
{
    public Game(int id, string name, string description, List<string> images, int stock, int categoryId) : base(id, name, description, images, stock, categoryId)
    { }
    public Game(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue,
        ProductPriceOV productPriceObjectValue,
        ProductSpecificationsOV productSpecificationsObjectValue,
        ProductWarrantyOV productWarrantyObjectValue,
        GameGeneralFeaturesOV gameGeneralFeaturesObjectsValue,
        GameSpecificationsOV gameSpecificationsObjectsValue,
        GameRequirementsOV gameRequirementsObjectsValue,
        int categoryId)
     : base(
         name,
         description,
         images,
         stock,
         productDataObjectValue,
         productFlagsObjectValue,
         productPriceObjectValue,
         productSpecificationsObjectValue,
         productWarrantyObjectValue,
         categoryId)
    {
        GameGeneralFeaturesObjectsValue = gameGeneralFeaturesObjectsValue;
        GameSpecificationsObjectsValue = gameSpecificationsObjectsValue;
        GameRequirementsObjectsValue = gameRequirementsObjectsValue;
    }

    public void GameUpdate(
        string name,
        string description,
        List<string> images,
        int stock,
        ProductDataOV productDataObjectValue,
        ProductFlagsOV productFlagsObjectValue, 
        ProductPriceOV productPriceObjectValue,
        ProductSpecificationsOV productSpecificationsObjectValue, 
        ProductWarrantyOV productWarrantyObjectValue,
        GameGeneralFeaturesOV gameGeneralFeaturesObjectsValue, 
        GameSpecificationsOV gameSpecificationsObjectsValue, 
        GameRequirementsOV gameRequirementsObjectsValue, 
        int categoryId)
    {
        ProductUpdate(
            name,
            description,
            images,
            stock,
            productDataObjectValue,
            productFlagsObjectValue,
            productPriceObjectValue,
            productSpecificationsObjectValue, 
            productWarrantyObjectValue, 
            categoryId);

        GameGeneralFeaturesObjectsValue = gameGeneralFeaturesObjectsValue;
        GameSpecificationsObjectsValue = gameSpecificationsObjectsValue;
        GameRequirementsObjectsValue = gameRequirementsObjectsValue;
    }
    public GameGeneralFeaturesOV GameGeneralFeaturesObjectsValue { get; private set; }
    public GameSpecificationsOV GameSpecificationsObjectsValue { get; private set; }
    public GameRequirementsOV GameRequirementsObjectsValue { get; private set; }
}
