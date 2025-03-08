using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IPetCardRepository
    {
        Task<PetCard> AddPetCard(PetCard petCard);
    }
}

