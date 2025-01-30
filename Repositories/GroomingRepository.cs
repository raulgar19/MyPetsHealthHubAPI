using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data.MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class GroomingRepository : IGroomingRepository
    {
        private readonly AppDbContext _context;

        public GroomingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Grooming>> GetAll()
        {
            return await _context.Groomings.ToListAsync();
        }
    }
}