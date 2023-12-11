using System.ComponentModel;

namespace Domain.Entities.Payments.Enums
{
    public enum EPaymentStatus
    {
        [Description("Pending payment")]
        Pending = 1,

        [Description("Processing")]
        Processing = 2,

        [Description("Approved")]
        Approved = 3,

        [Description("Declined")]
        Declined = 4,

        [Description("Refunded")]
        Refunded = 5,

        [Description("Completed")]
        Completed = 6,

        [Description("Canceled")]
        Canceled = 7
    }
    public static class EPaymentStatusExtensions
    {
        public static string GetDescription(this EPaymentStatus value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
