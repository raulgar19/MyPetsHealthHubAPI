using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IScheduledQueryRepository
    {
        Task<List<ScheduledQuery>> GetScheduledQueriesByVetId(int id);
    }
}
