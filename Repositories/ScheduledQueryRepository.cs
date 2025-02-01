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
            return await _context.ScheduledQueries.Where(s => s.VetId == id).ToListAsync();
        }
    }
}
