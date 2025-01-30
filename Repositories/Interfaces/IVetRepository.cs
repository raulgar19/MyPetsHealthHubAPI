using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IVetRepository
    {
        Task<List<Vet>> GetAll();
        Task<Vet> GetUserById(int id);
    }
}
