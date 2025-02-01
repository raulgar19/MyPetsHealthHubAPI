using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledQueriesController : ControllerBase
    {
        private readonly IScheduledQueryService _scheduledQueryService;

        public ScheduledQueriesController(IScheduledQueryService scheduledQueryService)
        {
            _scheduledQueryService = scheduledQueryService;
        }

        [HttpGet("getByVetId/{id}")]
        public async Task<ActionResult<List<Pet>>> GetPetsByVetId(int id)
        {
            var scheduledQueries = await _scheduledQueryService.GetScheduledQueriesByVetId(id);

            if (scheduledQueries == null || scheduledQueries.Count == 0)
            {
                return NotFound(new { message = "No se encontraron consultas para el veterinario especificado." });
            }

            return Ok(scheduledQueries);
        }
    }
}