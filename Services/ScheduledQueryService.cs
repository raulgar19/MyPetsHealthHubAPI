using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class ScheduledQueryService : IScheduledQueryService
    {
        private readonly IScheduledQueryRepository _scheduledQueryRepository;

        public ScheduledQueryService(IScheduledQueryRepository scheduledQueryRepository)
        {
            _scheduledQueryRepository = scheduledQueryRepository;
        }

        public async Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id)
        {
            return await _scheduledQueryRepository.GetScheduledQueriesByVetId(id);
        }
    }
}
