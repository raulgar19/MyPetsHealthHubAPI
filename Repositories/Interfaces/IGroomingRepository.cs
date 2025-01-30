using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IGroomingRepository
    {
        Task<List<Grooming>> GetAll();
    }
}
