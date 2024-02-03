using System.ComponentModel;

namespace Domain.Entities.Payments.Enums;

public enum EPaymentMethod
{
    [Description("Credit Card")]
    CreditCard = 1,

    [Description("Debit Card")]
    DebitCard = 2,

    [Description("PayPal")]
    PayPal = 3,

    [Description("Bank Transfer")]
    BankTransfer = 4,

    [Description("Cash On Delivery")]
    CashOnDelivery = 5
}

public static class EPaymentMethodHelper
{
    public static string GetDescription(this EPaymentMethod value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}
