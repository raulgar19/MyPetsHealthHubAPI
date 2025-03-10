using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IPetCardRepository
    {
        Task<PetCard> AddPetCard(PetCard petCard);
        Task DeletePetCard(PetCard petCard);
        Task<string> GetLastRegisterNumber();
        Task<PetCard> GetPetCard(int petCardId);
    }
}

