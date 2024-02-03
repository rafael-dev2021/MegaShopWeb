using Domain.Identity;
using Domain.Identity.Interfaces;
using Infra_Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Identity;

public class AuthenticateRepository(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, AppDbContext appDbContext) : IAuthenticateRepository
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly AppDbContext _appDbContext = appDbContext;

    private async Task<bool> IsSSNAlreadyUsed(string ssn)
    {
        var findBySsnAsync = await _appDbContext.Users.FirstOrDefaultAsync(s => s.SSN == ssn);
        return findBySsnAsync != null;
    }

    private async Task<bool> IsPhoneAlreadyUsed(string phone)
    {
        var userWithPhone = await _appDbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
        return userWithPhone != null;
    }


    public async Task<RegistrationResult> RegisterAsync(string email, string password, string firstName, string lastName, string phone, string ssn, DateTime birthDate)
    {
        if (await IsSSNAlreadyUsed(ssn))
        {
            return new RegistrationResult { IsRegistered = false, ErrorMessage = "SSN already registered." };
        }

        if (await IsPhoneAlreadyUsed(phone))
        {
            return new RegistrationResult { IsRegistered = false, ErrorMessage = "Phone number already registered." };
        }

        var appUser = new ApplicationUser()
        {
            Email = email,
            UserName = email,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phone,
            SSN = ssn,
            BirthDate = birthDate
        };

        var result = await _userManager.CreateAsync(appUser, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(appUser, "User");
            await _signInManager.SignInAsync(appUser, isPersistent: false);
            return new RegistrationResult { IsRegistered = true, ErrorMessage = "Registration successful." };
        }
        else
        {
            return new RegistrationResult { IsRegistered = false, ErrorMessage = "Registration failed. Email exist, please try again." };
        }
    }

    public async Task<AuthenticationResult> AuthenticateAsync(string email, string password, bool rememberMe)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: rememberMe, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            return new AuthenticationResult { IsAuthenticated = true, ErrorMessage = "Login successful" };
        }
        else if (result.IsLockedOut)
        {
            return new AuthenticationResult { IsAuthenticated = false, ErrorMessage = "Your account is locked. Please contact support." };
        }
        else
        {
            return new AuthenticationResult { IsAuthenticated = false, ErrorMessage = "Invalid email or password. Please try again." };
        }
    }


    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return false;
        }

        var changePasswordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

        return changePasswordResult.Succeeded;
    }

    public async Task<bool> ForgotPasswordAsync(string email, string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetPasswordResult = await _userManager.ResetPasswordAsync(user, token, newPassword);

        return resetPasswordResult.Succeeded;
    }

    public async Task<SeedUserUpdate> GetUserProfileAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return null;
        }


        var userProfile = new SeedUserUpdate
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.PhoneNumber,
            BirthDate = user.BirthDate,
            SSN = user.SSN,
            IsSubscribedToNewsletter = user.IsSubscribedToNewsletter
        };

        return userProfile;
    }

    public async Task<bool> UpdateProfileAsync(string email, string firstName, string lastName, string phone, DateTime birthDate, bool iSSubscribedToNewsletter)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return false;
        }

        user.FirstName = firstName;
        user.LastName = lastName;
        user.PhoneNumber = phone;
        user.BirthDate = birthDate;
        user.IsSubscribedToNewsletter = iSSubscribedToNewsletter;

        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }
}
