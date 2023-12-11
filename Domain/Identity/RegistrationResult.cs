namespace Domain.Identity
{
    public class RegistrationResult
    {
        public bool IsRegistered { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
