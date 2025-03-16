using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IScheduledQueryService
    {
        Task AddScheduledQuery(ScheduledQuery scheduledQuery);
        Task DeleteScheduledQueries(List<ScheduledQuery> scheduledQueries);
        Task<List<ScheduledQuery>> GetScheduledQueriesByPetId(List<Pet> pets);
        Task<List<ScheduledQuery>> GetScheduledQueriesByPetId(Pet pet);
        Task<List<ScheduledQuery>> GetScheduledQueriesByVetAndPetId(int petId, int vetId);
        Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id);
        Task<ScheduledQuery> GetScheduledQueryById(int id);
        Task RemoveScheduledQuery(ScheduledQuery query);
    }
}