using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetsController : ControllerBase
    {
        private readonly IVetService _vetService;

        public VetsController(IVetService vetService)
        {
            _vetService = vetService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Vet>>> GetAll()
        {
            List<Vet> vets = await _vetService.GetAll();
            if (vets == null)
            {
                return NotFound();
            }
            return Ok(vets);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Vet>> GetById(int id)
        {
            Vet vet = await _vetService.GetUserById(id);
            if (vet == null)
            {
                return NotFound();
            }
            return Ok(vet);
        }
    }
}