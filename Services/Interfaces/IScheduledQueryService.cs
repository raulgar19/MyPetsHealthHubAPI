using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IScheduledQueryService
    {
        Task AddScheduledQuery(ScheduledQuery scheduledQuery);
        Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id);
    }
}