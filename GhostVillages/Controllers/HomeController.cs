using GhostVillages.Application.Services;
using GhostVillages.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GhostVillages.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegionService _regionService;
        private readonly IVillageService _villageService;

        public HomeController(ILogger<HomeController> logger, IRegionService regionService, IVillageService villageService)
        {
            _logger = logger;
            _regionService = regionService;
            _villageService = villageService;
        }

        public async Task<ActionResult> Index()
        {
            var regions = await _regionService.GetList();

            return View(regions);
        }

        public async Task<ActionResult> Search(string query)
        {
            var villages = await _villageService.Search(query);

            return View(villages);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
