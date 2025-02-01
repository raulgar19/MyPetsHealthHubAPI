using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetPetsByVetId(int id);
    }
}