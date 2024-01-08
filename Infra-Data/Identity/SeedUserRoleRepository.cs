using Domain.Identity.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infra_Data.Identity;

public class SeedUserRoleRepository(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager) : ISeedUserRoleRepository
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    private async Task CreateRoleIfNotExists(string roleName)
    {
        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            IdentityRole role = new()
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            };
            _ = await _roleManager.CreateAsync(role);
        }
    }

    private async Task CreateUserIfNotExists(string email, string roleName)
    {
        if (await _userManager.FindByEmailAsync(email) == null)
        {
            var appUser = new ApplicationUser
            {
                Email = email,
                UserName = email,
                NormalizedEmail = email.ToUpper(),
                NormalizedUserName = email.ToUpper(),
                FirstName = "Rafael",
                LastName = "Silva",
                BirthDate = new DateTime(2000, 02, 20),
                SSN = "123-45-6789",
                PhoneNumber = "1614-240-7675",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, "@Visual23k+");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);
                await _userManager.AddClaimsAsync(appUser, new Claim[]
                {
                    new(JwtClaimTypes.Name, $"{appUser.FirstName} {appUser.LastName}"),
                    new(JwtClaimTypes.GivenName, appUser.FirstName),
                    new(JwtClaimTypes.FamilyName, appUser.LastName),
                    new(JwtClaimTypes.Role, roleName)
                });
            }
        }
    }

    public async Task SeedRoleAsync()
    {
        await CreateRoleIfNotExists("Admin");
        await CreateRoleIfNotExists("User");
    }

    public async Task SeedUserAsync()
    {
        await CreateUserIfNotExists("admin@localhost.com", "Admin");
        await CreateUserIfNotExists("user@localhost.com", "User");
    }
}
