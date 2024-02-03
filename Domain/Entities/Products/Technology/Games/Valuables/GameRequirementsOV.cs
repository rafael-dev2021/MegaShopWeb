namespace Domain.Entities.Products.Technology.Games.Valuables;

public class GameRequirementsOV
{
    public int MinimumRAMRequirement { get; protected set; }
    public string MinimumOperatingSystemsRequired { get; protected set; } = string.Empty;
    public string MinimumGraphicsProcessorsRequired { get; protected set; } = string.Empty;
    public string MinimumProcessorsRequired { get; protected set; } = string.Empty;
}
