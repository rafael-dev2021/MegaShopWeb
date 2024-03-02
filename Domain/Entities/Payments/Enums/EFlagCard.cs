using System.ComponentModel;

namespace Domain.Entities.Payments.Enums;

public enum EFlagCard
{
    [Description("Visa")]
    Visa,
    [Description("Mastercard")]
    Mastercard,
    [Description("Elo")]
    Elo,
    [Description("American Express")]
    AmericanExpress,
    [Description("Diners Club")]
    DinersClub,
    [Description("Hipercard")]
    Hipercard,
    [Description("Sorocred")]
    Sorocred,
    [Description("Cabal")]
    Cabal,
    [Description("Alura")]
    Aura,
    [Description("Alelo")]
    Alelo
}

public static class EFlagCardHelper
{
    public static string GetDescription(this EFlagCard value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}
