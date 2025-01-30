using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data.MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class VetRepository : IVetRepository
    {
        private readonly AppDbContext _context;

        public VetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vet>> GetAll()
        {
            return await _context.Vets.ToListAsync();
        }

        public async Task<Vet> GetUserById(int id)
        {
            return await _context.Vets.FirstOrDefaultAsync(v => v.VetUserId == id);
        }
    }
}