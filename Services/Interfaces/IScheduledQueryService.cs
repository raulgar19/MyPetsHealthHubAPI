using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IScheduledQueryService
    {
        Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id);
    }
}