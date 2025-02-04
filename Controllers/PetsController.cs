using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("getByVetId/{id}")]
        public async Task<ActionResult<List<Pet>>> GetPetsByVetId(int id)
        {
            var pets = await _petService.GetPetsByVetId(id);

            if (pets == null || pets.Count == 0)
            {
                return NotFound(new { message = "No se encontraron mascotas para el veterinario especificado." });
            }

            return Ok(pets);
        }

        [HttpGet("getByUserId/{id}")]
        public async Task<ActionResult<List<Pet>>> GetByUserId(int id)
        {
            var pets = await _petService.GetPetsByUserId(id);

            if (pets == null || pets.Count == 0)
            {
                return NotFound(new { message = "No se encontraron mascotas para el veterinario especificado." });
            }

            return Ok(pets);
        }
    }
}