using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class PetCardService : IPetCardService
    {
        private readonly IPetCardRepository _petCardRepository;

        public PetCardService(IPetCardRepository petCardRepository)
        {
            _petCardRepository = petCardRepository;
        }

        public async Task<PetCard> AddPetCard(PetCard petCard)
        {
            return await _petCardRepository.AddPetCard(petCard);
        }
    }
}