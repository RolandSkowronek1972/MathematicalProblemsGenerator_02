using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyApp.Models;

namespace MyApp.Controllers;

public class HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer) : ServiceStackController
{

   

    private readonly ILogger<HomeController> _logger = logger;
    private  IStringLocalizer<HomeController> _localizer = localizer;


    //public IActionResult Index() => View();
    public IActionResult Index()
    {
        var localisedTitle = _localizer["Welcome"];
    return View();
    
    }

    public IActionResult Privacy() => View();
    public async Task<IActionResult> Bookings()
    {
        var response = await Gateway.ApiAsync(new QueryBookings { 
            OrderByDesc = nameof(Booking.Id),
            Take = 10,
        });

        return View(response.Response);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
