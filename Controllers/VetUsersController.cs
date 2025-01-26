using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetUsersController : ControllerBase
    {
        private readonly IVetUserService _vetUserService;

        public VetUsersController(IVetUserService vetUserService)
        {
            _vetUserService = vetUserService;
        }

        [HttpPost("vetLogin")]
        public async Task<ActionResult<VetUser>> VetLogin([FromBody] LoginModel credentials)
        {
            VetUser vetUser = await _vetUserService.VetLogin(credentials.Email, credentials.Password);
            if (vetUser == null)
            {
                return NotFound();
            }
            return Ok(vetUser);
        }
    }
}