
using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Models.RequestModels;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IPetCardService _petCardService;
        private readonly IAppUserService _appUserService;

        public PetsController(IPetService petService, IPetCardService petCardService, IAppUserService appUserService)
        {
            _petService = petService;
            _petCardService = petCardService;
            _appUserService = appUserService;
        }

        [HttpPost("addPet")]
        public async Task<ActionResult<Pet>> AddPet([FromBody] RegisterPetModel petRegisterModel)
        {
            if (petRegisterModel == null)
            {
                return BadRequest(new { message = "No se recibieron datos para agregar la mascota." });
            }

            PetCard petCard = new PetCard
            {
                QrCode = petRegisterModel.Chip
            };

            PetCard newPetCard = await _petCardService.AddPetCard(petCard);

            Vet vet = await _appUserService.GetVetByUserId(petRegisterModel.UserId);

            Pet pet = new Pet
            {
                Chip = petRegisterModel.Chip,
                Name = petRegisterModel.Name,
                Species = petRegisterModel.Species,
                Breed = petRegisterModel.Breed,
                Birthday = petRegisterModel.Birthday,
                Weight = petRegisterModel.Weight,
                Gender = petRegisterModel.Gender,
                Notes = petRegisterModel.Notes,
                LastVaccination = petRegisterModel.LastVaccination,
                PetCardId = newPetCard.Id,
                AppUserId = petRegisterModel.UserId,
                VetId = vet.Id,
            };

                await _petService.AddPet(pet);
            
            return Ok();
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Pet>> GetPetsById(int id)
        {
            var pet = await _petService.GetPetById(id);

            if (pet == null)
            {
                return NotFound(new { message = "No se encontraron mascotas para el identificador especificado." });
            }

            return Ok(pet);
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
                return NotFound(new { message = "No se encontraron mascotas para el usuario especificado." });
            }

            return Ok(pets);
        }
    }
}