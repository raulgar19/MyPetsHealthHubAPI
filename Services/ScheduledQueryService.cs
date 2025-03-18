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

        public async Task<List<ScheduledQuery>> GetScheduledQueriesByPetId(List<Pet> pets)
        {
            List<ScheduledQuery> scheduledQueries = new List<ScheduledQuery>();

            foreach (Pet pet in pets)
            {
                List<ScheduledQuery> petQueries = await _scheduledQueryRepository.GetScheduledQueriesByPetId(pet.Id);

                foreach (ScheduledQuery scheduledQuery in petQueries)
                {
                    scheduledQueries.Add(scheduledQuery);
                }
            }
            return scheduledQueries;
        }

        public async Task<List<ScheduledQuery>> GetScheduledQueriesByPetId(Pet pet)
        {
            return await _scheduledQueryRepository.GetScheduledQueriesByPetId(pet.Id);
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
            return await _scheduledQueryRepository.GetScheduledQueryById(id);
        }

        public async Task<List<ScheduledQuery>> GetScheduledQueriesByUserId(int userId)
        {
            return await _scheduledQueryRepository.GetScheduledQueriesByUserId(userId);
        }

        public async Task RemoveScheduledQuery(ScheduledQuery query)
        {
            await _scheduledQueryRepository.RemoveScheduledQuery(query);
        }

        public async Task DeleteScheduledQueries(List<ScheduledQuery> scheduledQueries)
        {
            await _scheduledQueryRepository.DeleteScheduledQueries(scheduledQueries);
        }
    }
}