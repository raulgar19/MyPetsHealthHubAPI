using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IPetCardService
    {
        Task<PetCard> AddPetCard(PetCard petCard);
    }
}
