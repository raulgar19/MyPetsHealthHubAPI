using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Models.RequestModels;
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

        [HttpPost("addQuery")]
        public async Task<ActionResult> AddScheduledQuery([FromBody] RegisterQueryModel registerQueryModel)
        {
            if (registerQueryModel.PetId <= 0 || registerQueryModel.VetId <= 0)
            {
                return BadRequest(new { message = "El ID de la mascota y del veterinario son obligatorios." });
            }

            ScheduledQuery scheduledQuery = new ScheduledQuery
            {
                Date = registerQueryModel.Date,
                Hour = registerQueryModel.Hour,
                Purpose = registerQueryModel.Purpose,
                RequiredActions = registerQueryModel.RequiredActions,
                PreviewInstructions = registerQueryModel.PreviewInstructions,
                FollowUpActions = registerQueryModel.FollowUpActions,
                VetId = registerQueryModel.VetId,
                PetId = registerQueryModel.PetId
            };

            await _scheduledQueryService.AddScheduledQuery(scheduledQuery);
            return Ok();
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

        [HttpGet("getPetQueries")]
        public async Task<ActionResult<List<ScheduledQuery>>> GetPetQueries([FromQuery] int petId, [FromQuery] int vetId)
        {
            List<ScheduledQuery> scheduledQueries = await _scheduledQueryService.GetScheduledQueriesByVetAndPetId(petId, vetId);
            if (scheduledQueries == null || scheduledQueries.Count == 0)
            {
                return NotFound(new { message = "No se encontraron consultas para la mascota especificada." });
            }
            return Ok(scheduledQueries);
        }

        [HttpDelete("removeQuery/{id}")]
        public async Task<ActionResult> RemoveQuery(int id)
        {
            ScheduledQuery query = await _scheduledQueryService.GetScheduledQueryById(id);

            await _scheduledQueryService.RemoveScheduledQuery(query);
            return Ok();
        }
    }
}