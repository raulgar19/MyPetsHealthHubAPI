using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IPetCardRepository
    {
        Task<PetCard> AddPetCard(PetCard petCard);
        Task DeletePetCard(PetCard petCard);
        Task DeleteUserPetsPetCards(List<PetCard> petCards);
        Task<string> GetLastRegisterNumber();
        Task<PetCard> GetPetCard(int petCardId);
    }
}

