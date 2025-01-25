using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProjectV2._0.Models;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace WebProjectV2._0.Controllers;

public class HomeController : Controller
{



    private readonly ILogger<HomeController> _logger;
    private HomeModel home = new HomeModel();

    public HomeController(ILogger<HomeController> logger)
    {
        Console.WriteLine("testing controller");
        _logger = logger;
    }



    public IActionResult Index()
    {
    
        return View();


    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        if(home.SignIn(username, password);)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {

        };
        HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties
        );
        }
        

        Console.WriteLine("onpostview WOrks");

        return View();
    }   

    [Authorize]
    public void loggedin()
    {
        Console.WriteLine("the user is logged in");
    }
}
