using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IPetCardService
    {
        Task<PetCard> AddPetCard(PetCard petCard);
        Task DeletePetCard(PetCard petCard);
        Task<string> GetLastRegisterNumber();
        Task<List<PetCard>> GetUserPetCards(List<Pet> pets);
    }
}
