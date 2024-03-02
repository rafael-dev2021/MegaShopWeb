namespace Domain.Entities.Products.Technology.Smartphones.Valuables;

public class SmartphoneBatteryOV
{
    public string BatteryType { get; protected set; } = string.Empty;
    public int BatteryCapacitymAh { get; protected set; }
    public bool IsBatteryRemovable { get; protected set; }
}
