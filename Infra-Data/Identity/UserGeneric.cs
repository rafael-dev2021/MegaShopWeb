using Domain.Entities.Deliveries;
using Domain.Entities.Payments.Enums;
using Microsoft.AspNetCore.Identity;

namespace Infra_Data.Identity
{
    public class UserGeneric : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SSN { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public EPaymentMethod DefaultPaymentMethod { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public List<DeliveryAddress> DeliveryAddress { get; set; } = [];
    }
}
