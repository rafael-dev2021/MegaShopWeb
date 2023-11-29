namespace Application.Services.Discounts.ValueObjects
{
    public class CalculateDiscountOV
    {
        public decimal DiscountPercentage { get; set; }
        public decimal InTwelveInstallmentWithoutInterest { get; set; }
        public decimal InThreeInstallmentWithInterest { get; set; }
        public decimal InSixInstallmentWithoutInterest { get; set; }
    }
}
