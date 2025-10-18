using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_service_mvc.Models;

namespace web_service_mvc.Controllers;

public class CatPersonalController : Controller
{
    private readonly ILogger<CatPersonalController> _logger;

    public CatPersonalController(ILogger<CatPersonalController> logger)
    {
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
}
