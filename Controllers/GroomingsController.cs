using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroomingsController : ControllerBase
    {
        private readonly IGroomingService _groomingService;

        public GroomingsController(IGroomingService groomingService)
        {
            _groomingService = groomingService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Grooming>>> GetAll()
        {
            List<Grooming> groomings = await _groomingService.GetAll();
            if (groomings == null)
            {
                return NotFound();
            }
            return Ok(groomings);
        }
    }
}