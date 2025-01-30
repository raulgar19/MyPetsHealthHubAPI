using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IEmergencyService
    {
        Task<List<Emergency>> GetAll();
    }
}