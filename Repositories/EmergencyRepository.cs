using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data.MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class EmergencyRepository : IEmergencyRepository
    {
        private readonly AppDbContext _context;

        public EmergencyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Emergency>> GetAll()
        {
            return await _context.Emergencies.ToListAsync();
        }
    }
}
