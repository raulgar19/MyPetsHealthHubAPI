using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IPetService
    {
        Task<Pet> GetPetById(int id);
        Task<List<Pet>> GetPetsByUserId(int id);
        Task<List<Pet>> GetPetsByVetId(int id);
    }
}