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

        public async Task AddScheduledQuery(ScheduledQuery scheduledQuery)
        {
            await _scheduledQueryRepository.AddScheduledQuery(scheduledQuery);
        }

        public async Task<List<ScheduledQuery>> GetScheduledQueriesByVetAndPetId(int petId, int vetId)
        {
            return await _scheduledQueryRepository.GetScheduledQueriesByVetAndPetId(petId, vetId);
        }

        public async Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id)
        {
            return await _scheduledQueryRepository.GetScheduledQueriesByVetId(id);
        }

        public async Task<ScheduledQuery> GetScheduledQueryById(int id)
        {
            return await _scheduledQueryRepository.GetScheduledQueriesById(id);
        }

        public async Task RemoveScheduledQuery(ScheduledQuery query)
        {
            await _scheduledQueryRepository.RemoveScheduledQuery(query);
        }
    }
}