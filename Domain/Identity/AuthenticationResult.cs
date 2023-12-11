namespace Domain.Identity
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
