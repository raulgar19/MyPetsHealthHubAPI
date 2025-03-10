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

        public async Task<string> GetLastRegisterNumber()
        {
            string lastRegisterNumber = await _petCardRepository.GetLastRegisterNumber();

            if (lastRegisterNumber == null)
            {
                return "0000000000";
            }
            return lastRegisterNumber;
        }

        public async Task<List<PetCard>> GetUserPetCards(List<Pet> pets)
        {
            List<PetCard> petCards = new List<PetCard>();

            foreach (Pet pet in pets)
            {
                petCards.Add(await _petCardRepository.GetPetCard(pet.PetCardId));
            }
            return petCards;
        }

        public async Task DeletePetCard(PetCard petCard)
        {
            await _petCardRepository.DeletePetCard(petCard);
        }
    }
}