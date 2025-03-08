using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IScheduledQueryRepository
    {
        Task AddScheduledQuery(ScheduledQuery scheduledQuery);
        Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id);
    }
}