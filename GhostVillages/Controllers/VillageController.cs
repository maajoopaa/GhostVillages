using GhostVillages.Application.Services;
using GhostVillages.DataAccess.Entities;
using GhostVillages.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GhostVillages.Controllers
{
    public class VillageController : Controller
    {
        private readonly IVillageService _villageService;
        private readonly IUserService _userService;
        private readonly IRegionService _regionService;

        public VillageController(IVillageService villageService, IUserService userService, IRegionService regionService)
        {
            _villageService = villageService;
            _userService = userService;
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetVillage(string id)
        {
            var village = await _villageService.Get(Guid.Parse(id));

            var regions = await _regionService.GetList();

            ViewData["Regions"] = regions;

            return View(village);
        }

        [HttpGet]
        public async Task<ActionResult> CreateVillage()
        {
            var regions = await _regionService.GetList();

            return PartialView(regions);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVillage([FromBody] VillageRequest model)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var village = await _villageService.Create(model.Title, model.Description, Convert.FromBase64String(model.Image), Guid.Parse(model.RegionId));

                if (village != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateVillage(string id, [FromBody] VillageRequest model)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var village = await _villageService.Update(Guid.Parse(id), model.Title, model.Description, Convert.FromBase64String(model.Image), Guid.Parse(model.RegionId));

                if (village != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveVillage(string id)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var isSuccess = await _villageService.Remove(Guid.Parse(id));

                if (isSuccess)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        private async Task<UserEntity?> GetUser()
        {
            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (claimValue is not null)
            {
                var user = await _userService.Get(Guid.Parse(claimValue));

                return user;
            }

            return null;
        }
    }
}
