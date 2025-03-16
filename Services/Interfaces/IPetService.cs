using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Models.RequestModels;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IPetService
    {
        Task AddPet(Pet pet);
        Task DeletePet(Pet pet);
        Task DeleteUserPets(List<Pet> pets);
        Task<Pet> GetPetById(int id);
        Task<List<Pet>> GetPetsByUserId(int id);
        Task<List<Pet>> GetPetsByVetId(int id);
    }
}