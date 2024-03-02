using Domain.Identity.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebUI.ViewModels.IdentityViewModel;

namespace WebUI.Controllers;

public class AccountController(IAuthenticateRepository authenticateRepository) : Controller
{
    private readonly IAuthenticateRepository _authenticateRepository = authenticateRepository;

    [AllowAnonymous]
    public IActionResult Login(string returnUrl) =>
        View(new LoginViewModel()
        { ReturnUrl = returnUrl });


    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var authenticationResult = await _authenticateRepository.AuthenticateAsync(model.Email, model.Password, model.RememberMe);

        if (authenticationResult.IsAuthenticated)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl))
                return RedirectToAction("Index", "Home");

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, model.Email),
                new(ClaimTypes.Role, "User")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, authenticationResult.ErrorMessage);
        }

        return View(model);
    }


    [AllowAnonymous]
    public IActionResult Register() => View();

    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var registrationResult = await _authenticateRepository.RegisterAsync(model.Email, model.Password, model.FirstName, model.LastName, model.Phone, model.SSN, model.BirthDate);

        if (registrationResult.IsRegistered)
            return Redirect("/");

        ModelState.AddModelError(string.Empty, registrationResult.ErrorMessage);
        return View(model);
    }



    [Authorize]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();
        HttpContext.User = null;

        await _authenticateRepository.LogoutAsync();
        return Redirect("/Account/Login");
    }

    [Authorize]
    public IActionResult AccessDenied() => View();

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var userEmail = User.Identity.Name;
        var userProfile = await _authenticateRepository.GetUserProfileAsync(userEmail);

        if (userProfile == null)
            return NotFound();

        var model = new EditProfileViewModel
        {
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Phone = userProfile.Phone,
            BirthDate = userProfile.BirthDate,
            SSN = userProfile.SSN
        };

        return View(model);
    }

    [Authorize]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> EditProfile(EditProfileViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var userEmail = User.Identity.Name;

        var updateResult = await _authenticateRepository
            .UpdateProfileAsync(
            userEmail,
            model.FirstName,
            model.LastName,
            model.Phone,
            model.BirthDate,
            model.IsSubscribedToNewsletter);

        if (updateResult)
            return RedirectToAction("EditProfileSuccess");

        ModelState.AddModelError(string.Empty, "Failed to update profile.");
        return View(model);
    }

    [Authorize]
    public IActionResult EditProfileSuccess() => View();

    [Authorize]
    public IActionResult ChangePassword() => View();

    [Authorize]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var userEmail = User.Identity.Name;

        var changePasswordResult = await _authenticateRepository
            .ChangePasswordAsync(
            userEmail,
            model.OldPassword,
            model.NewPassword);

        if (changePasswordResult)
            return RedirectToAction("ChangePasswordSuccess");

        ModelState.AddModelError(string.Empty, "Failed to change password.");
        return View(model);
    }
    [Authorize]
    public IActionResult ChangePasswordSuccess() => View();


    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> ResetPassword(PasswordResetViewModel model)
    {
        if (ModelState.IsValid)
        {
            var resetResult = await _authenticateRepository.ForgotPasswordAsync(model.Email, model.NewPassword);

            if (resetResult)
                return View("PasswordResetSuccess");

            ModelState.AddModelError(string.Empty,
                "An error occurred while resetting the password, user not found.");
        }

        return View(model);
    }
    public IActionResult ResetPassword() => View();
    public IActionResult PasswordResetSuccess() => View();
}
