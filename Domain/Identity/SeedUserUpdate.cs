namespace Domain.Identity;

public sealed class SeedUserUpdate
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string SSN { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }
}
