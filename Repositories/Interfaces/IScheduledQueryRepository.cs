using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IScheduledQueryRepository
    {
        Task AddScheduledQuery(ScheduledQuery scheduledQuery);
        Task<ScheduledQuery> GetScheduledQueriesById(int id);
        Task<List<ScheduledQuery>> GetScheduledQueriesByVetAndPetId(int petId, int vetId);
        Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id);
        Task RemoveScheduledQuery(ScheduledQuery query);
    }
}