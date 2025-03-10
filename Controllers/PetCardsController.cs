using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetCardsController : ControllerBase
    {
        private readonly IPetCardService _petCardService;
        private readonly IPetService _petService;

        public PetCardsController(IPetCardService petCardService, IPetService petService)
        {
            _petCardService = petCardService;
            _petService = petService;
        }

        [HttpGet("userPetCards/{id}")]
        public async Task<ActionResult<List<Pet>>> GetUserPetCards(int id)
        {
            List<Pet> petsAndPetCards = await _petService.GetPetsByUserId(id);

            if (petsAndPetCards == null)
            {
                return NotFound();
            }

            return Ok(petsAndPetCards);
        }
    }
}
