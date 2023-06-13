using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webapp_mvc.Models;

namespace webapp_mvc.Controllers;
public class TestController : Controller
{
    /**
    **A generic interface for logging where the category name is derived from the specified HomeController type name. Generally used to enable activation of a
    ** named ILogger from dependency injection.
    */
    private readonly ILogger<TestController> _logger;
    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index(){
        return View();
    }
     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}