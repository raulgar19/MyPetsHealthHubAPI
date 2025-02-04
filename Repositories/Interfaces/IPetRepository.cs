using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<Pet> GetPetById(int id);
        Task<List<Pet>> GetPetsByUserId(int id);
        Task<List<Pet>> GetPetsByVetId(int id);
    }
}