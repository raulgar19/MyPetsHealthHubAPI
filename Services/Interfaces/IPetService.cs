using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IPetService
    {
        Task<List<Pet>> GetPetsByVetId(int id);
    }
}