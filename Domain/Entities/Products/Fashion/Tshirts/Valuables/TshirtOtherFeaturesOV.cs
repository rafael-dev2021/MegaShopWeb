namespace Domain.Entities.Products.Fashion.Tshirts.Valuables;

public class TshirtOtherFeaturesOV
{
    public string RecommendedUses { get; protected set; } = string.Empty;
    public string KindOfFabric { get; protected set; } = string.Empty;
    public string Composition { get; protected set; } = string.Empty;
    public string MainMaterial { get; protected set; } = string.Empty;
    public string SleeveType { get; protected set; } = string.Empty;
    public string TypeOfCollar { get; protected set; } = string.Empty;
    public int UnitsPerKit { get; protected set; }
    public bool WithRecycledMaterials { get; protected set; }
    public bool ItsSporty { get; protected set; }
}
