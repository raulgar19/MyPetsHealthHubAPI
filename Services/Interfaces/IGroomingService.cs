using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IGroomingService
    {
        Task<List<Grooming>> GetAll();
    }
}
