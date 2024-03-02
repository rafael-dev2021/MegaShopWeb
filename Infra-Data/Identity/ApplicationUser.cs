using Microsoft.AspNetCore.Identity;

namespace Infra_Data.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string SSN { get; set; } 
    public DateTime BirthDate { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }
}
