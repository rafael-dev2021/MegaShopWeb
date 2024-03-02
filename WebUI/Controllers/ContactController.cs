using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class ContactController : Controller
{
    [AllowAnonymous]
    public IActionResult About() => View();

    [AllowAnonymous]
    public IActionResult Contact() => View();
}
