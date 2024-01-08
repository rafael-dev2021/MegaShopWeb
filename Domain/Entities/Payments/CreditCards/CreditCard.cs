//using Domain.Entities.Payments.Enums;

//namespace Domain.Entities.Payments.CreditCards
//{
//    public class CreditCard : Payment
//    {
//        //public string CardNumber { get; set; } = string.Empty;
//        //public string CardHolderName { get; set; } = string.Empty;
//        //public string ExpirationDate { get; set; } = string.Empty;
//        //public string CVV { get; set; } = string.Empty;
//        //public Guid Reference { get; set; } = new Guid();
//        public override void Pay(EPaymentMethod ePayment)
//        {
//            switch (ePayment)
//            {
//                case EPaymentMethod.CreditCard:
//                    // Process Credit Card payment logic
//                    if (ValidateCreditCardDetails())
//                    {
//                        bool paymentSuccess = ProcessCreditCardPayment();
//                        if (paymentSuccess)
//                        {
//                            Console.WriteLine($"Credit Card payment successful for {Amount:C}.");
//                        }
//                        else
//                        {
//                            Console.WriteLine($"Credit Card payment failed for {Amount:C}.");
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine("Invalid Credit Card details. Payment failed.");
//                    }
//                    break;
//                // Add cases for other payment methods if needed
//                default:
//                    // Handle unknown payment method
//                    Console.WriteLine("Unknown payment method.");
//                    break;
//            }

//            // Call the base class implementation for common logic
//            base.Pay(ePayment);

//            // Additional credit card specific logic if needed
//        }
//        private bool ValidateCreditCardDetails()
//        {
//            if (string.IsNullOrWhiteSpace(CardNumber) || string.IsNullOrWhiteSpace(CardHolderName) ||
//                string.IsNullOrWhiteSpace(ExpirationDate) || string.IsNullOrWhiteSpace(CVV))
//            {
//                Console.WriteLine("Invalid credit card details. Please provide all required information.");
//                return false;
//            }
//            return false;
//        }

//        private bool ProcessCreditCardPayment()
//        {
//            Console.WriteLine($"Processing payment of {Amount:C} using Credit Card...");
//            Console.WriteLine("Contacting payment gateway...");

//            // Simulate a delay to mimic the time it takes to process a payment
//            Thread.Sleep(2000);
//            return true;
//        }
//    }
//}


////private bool ValidateCreditCardDetails()
////{
////    // Implement a more robust validation logic
////    // Check if the card number, cardholder name, expiration date, and CVV are provided
////    return !string.IsNullOrWhiteSpace(CardNumber) && !string.IsNullOrWhiteSpace(CardHolderName) &&
////           !string.IsNullOrWhiteSpace(ExpirationDate) && !string.IsNullOrWhiteSpace(CVV);
////}

////private async Task<bool> ProcessCreditCardPayment()
////{
////    StripeConfiguration.ApiKey = "your_stripe_api_key";

////    var options = new ChargeCreateOptions
////    {
////        Amount = (long)(Amount * 100),
////        Currency = "usd",
////        Source = "tok_visa", // Use a token representing the credit card details
////        Description = "Payment for Order #12345",
////    };

////    var service = new ChargeService();
////    var charge = await service.CreateAsync(options);

////    return charge.Paid;
////}

////public override async void Pay(EPaymentMethod ePayment)
////{
////    switch (ePayment)
////    {
////        case EPaymentMethod.CreditCard:
////            if (ValidateCreditCardDetails())
////            {
////                bool paymentSuccess = await ProcessCreditCardPayment();
////                if (paymentSuccess)
////                {
////                    Console.WriteLine($"Credit Card payment successful for {Amount:C}.");
////                }
////                else
////                {
////                    Console.WriteLine($"Credit Card payment failed for {Amount:C}.");
////                }
////            }
////            else
////            {
////                Console.WriteLine("Invalid Credit Card details. Payment failed.");
////            }
////            break;
////        default:
////            Console.WriteLine("Unknown payment method.");
////            break;
////    }

////    base.Pay(ePayment);
////}