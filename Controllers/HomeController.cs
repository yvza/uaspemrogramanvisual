using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using mvcwithlogin.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        ViewBag.uuid = userId;
        return View();
    }

    [Authorize]
    public IActionResult Playgame()
    {
        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        ViewBag.Tes = userId;
        ViewBag.uuid = userId;
        return View();
    }

    [Authorize]
    public IActionResult Userstats()
    {
        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        ViewBag.uuid = userId;
        return View();
    }

    [Authorize]
    public IActionResult Banstats()
    {
        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        ViewBag.uuid = userId;
        return View();
    }

    [Authorize]
    public IActionResult Controlarea()
    {
        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        ViewBag.uuid = userId;
        TempData["uuid"] = userId;
        // return View();
        // return RedirectToAction("Index", "ControlArea");
        return Redirect("/ControlArea");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
