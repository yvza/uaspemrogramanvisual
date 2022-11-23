using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using mvcwithlogin.Models;

namespace mvcwithlogin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult Playgame()
    {
        return View();
    }

    [Authorize]
    public IActionResult Userstats()
    {
        return View();
    }

    [Authorize]
    public IActionResult Banstats()
    {
        return View();
    }

    [Authorize]
    public IActionResult Controlarea()
    {
        return Redirect("/ControlArea");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
