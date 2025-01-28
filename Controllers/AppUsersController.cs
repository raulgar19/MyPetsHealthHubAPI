using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models.RequestModels;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost("userLogin")]
        public async Task<ActionResult<AppUser>> UserLogin([FromBody] LoginModel credentials)
        {
            AppUser appUser = await _appUserService.UserLogin(credentials.Email, credentials.Password);
            if (appUser == null)
            {
                return NotFound();
            }
            return Ok(appUser);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            AppUser appUser = await _appUserService.GetUserById(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return Ok(appUser);
        }
    }
}