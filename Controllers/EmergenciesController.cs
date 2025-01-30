using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergenciesController : ControllerBase
    {
        private readonly IEmergencyService _emergencyService;

        public EmergenciesController(IEmergencyService emergencyService)
        {
            _emergencyService = emergencyService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Emergency>>> GetAll()
        {
            List<Emergency> emergencies = await _emergencyService.GetAll();
            if (emergencies == null)
            {
                return NotFound();
            }
            return Ok(emergencies);
        }
    }
}