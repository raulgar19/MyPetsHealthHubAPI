using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data.MyPetsHealthHubApi.Data;
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

        public async Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id)
        {
            DateTime now = DateTime.Now;

            return await _context.ScheduledQueries
                .Where(s => s.VetId == id &&
                    (s.Date.Date > now.Date || (s.Date.Date == now.Date && s.Hour >= now.TimeOfDay)))
                .ToListAsync();
        }
    }
}