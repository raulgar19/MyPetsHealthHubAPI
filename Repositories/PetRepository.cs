using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data.MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AppDbContext _context;

        public PetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pet>> GetPetsByVetId(int id)
        {
            return await _context.Pets.Where(p => p.VetId == id).ToListAsync();
        }
    }
}