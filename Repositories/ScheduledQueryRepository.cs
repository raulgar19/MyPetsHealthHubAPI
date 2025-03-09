using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class ScheduledQueryRepository : IScheduledQueryRepository
    {
        private readonly AppDbContext _context;

        public ScheduledQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddScheduledQuery(ScheduledQuery scheduledQuery)
        {
            await _context.ScheduledQueries.AddAsync(scheduledQuery);
            await _context.SaveChangesAsync();
        }

        public async Task<ScheduledQuery> GetScheduledQueriesById(int id)
        {
            return await _context.ScheduledQueries.FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<List<ScheduledQuery>> GetScheduledQueriesByVetAndPetId(int petId, int vetId)
        {
            return _context.ScheduledQueries
                .Where(s => s.PetId == petId && s.VetId == vetId)
                .ToListAsync();
        }

        public async Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id)
        {
            DateTime now = DateTime.Now;

            return await _context.ScheduledQueries
                .Where(s => s.VetId == id &&
                    (s.Date.Date > now.Date || (s.Date.Date == now.Date && s.Hour >= now.TimeOfDay)))
                .Include(s => s.Pet)
                .ThenInclude(p => p.AppUser)
                .ToListAsync();
        }

        public async Task RemoveScheduledQuery(ScheduledQuery query)
        {
            _context.ScheduledQueries.Remove(query);
            await _context.SaveChangesAsync();
        }
    }
}