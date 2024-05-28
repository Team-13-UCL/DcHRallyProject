using DcHRally.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RallyBaneTest.Models;
using RallyBaneTest.ViewModels;
using System.Diagnostics;

namespace IdentityTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RallyDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, RallyDbContext context, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            var tracks = _context.Tracks
                    .Where(t => t.UserId == user.Id)
                    .OrderByDescending(t => t.TrackId)
                    .Take(8)
                    .ToList();
            return View("IndexLoggedIn", new TrackViewModel(null, tracks, null));
        }
        return View("IndexNotLoggedIn");
    }

    [Authorize(Roles = "Admin")]
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
