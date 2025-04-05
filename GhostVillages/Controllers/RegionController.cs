using GhostVillages.Application.Services;
using GhostVillages.DataAccess.Entities;
using GhostVillages.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GhostVillages.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;
        private readonly IUserService _userService;

        public RegionController(IRegionService regionService, IUserService userService)
        {
            _regionService = regionService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetRegion(string id)
        {
            var period = await _regionService.Get(Guid.Parse(id));

            return View(period);
        }

        [HttpGet]
        public ActionResult CreateRegion()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CreateRegion([FromBody] RegionRequest model)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var region = await _regionService.Create(model.Title, model.Description, Convert.FromBase64String(model.Image));

                if (region != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRegion(string id, [FromBody] RegionRequest model)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var region = await _regionService.Update(Guid.Parse(id), model.Title, model.Description, Convert.FromBase64String(model.Image));

                if (region != null)
                {
                    return StatusCode(200);
                }

                return StatusCode(404);
            }

            return StatusCode(403);
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveRegion(string id)
        {
            var user = await GetUser();

            if (user != null && user.IsAdmin == 1)
            {
                var isSuccess = await _regionService.Remove(Guid.Parse(id));

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
