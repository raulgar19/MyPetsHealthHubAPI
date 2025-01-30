using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IEmergencyRepository
    {
        Task<List<Emergency>> GetAll();
    }
}
