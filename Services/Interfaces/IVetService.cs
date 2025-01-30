using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IVetService
    {
        Task<List<Vet>> GetAll();
        Task<Vet> GetUserById(int id);
    }
}
