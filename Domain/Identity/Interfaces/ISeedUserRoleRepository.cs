namespace Domain.Identity.Interfaces;

public interface ISeedUserRoleRepository
{
    Task SeedUserAsync();
    Task SeedRoleAsync();
}
