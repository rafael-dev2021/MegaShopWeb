using Domain.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infra_Data.Identity;
public class SeedUserRoleRepository(RoleManager<IdentityRole> roleManager, UserManager<UserGeneric> userManager) : ISeedUserRoleRepository
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly UserManager<UserGeneric> _userManager = userManager;

    public async Task SeedRoleAsync()
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            IdentityRole role = new()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            _ = await _roleManager.CreateAsync(role);
        }

        if (!await _roleManager.RoleExistsAsync("User"))
        {
            IdentityRole role = new()
            {
                Name = "User",
                NormalizedName = "USER"
            };
            _ = await _roleManager.CreateAsync(role);
        }
    }

    public async Task SeedUserAsync()
    {
        if (await _userManager.FindByEmailAsync("admin@localhost.com") == null)
        {
            var userGeneric = new UserGeneric
            {
                Email = "admin@localhost.com",
                UserName = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                FirstName = "Rafael",
                LastName = "Silva",
                BirthDate = new DateTime(2000, 02, 20),
                SSN = "123-55-6789",
                PhoneNumber = "1624-240-7675",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(userGeneric, "@Visual23k+");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userGeneric, "Admin");
            }
        }

        if (await _userManager.FindByEmailAsync("user@localhost.com") == null)
        {
            var userGeneric = new UserGeneric
            {
                Email = "user@localhost.com",
                UserName = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                NormalizedUserName = "USER@LOCALHOST.COM",
                FirstName = "Rafael",
                LastName = "Silva",
                BirthDate = new DateTime(2000, 02, 20),
                SSN = "123-45-6789",
                PhoneNumber = "1614-240-7675",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(userGeneric, "@Visual23k+");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userGeneric, "User");
            }
        }
    }
}
