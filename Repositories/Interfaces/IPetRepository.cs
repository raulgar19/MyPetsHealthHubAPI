using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task AddPet(Pet pet);
        Task DeletePet(Pet pet);
        Task<Pet> GetPetById(int id);
        Task<List<Pet>> GetPetsByUserId(int id);
        Task<List<Pet>> GetPetsByVetId(int id);
    }
}