using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IPetCardRepository _petCardRepository;

        public PetService(IPetRepository petRepository, IPetCardRepository petCardRepository)
        {
            _petRepository = petRepository;
            _petCardRepository = petCardRepository;
        }

        public async Task AddPet(Pet pet)
        {
            await _petRepository.AddPet(pet);
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _petRepository.GetPetById(id);
        }

        public Task<List<Pet>> GetPetsByUserId(int id)
        {
            return _petRepository.GetPetsByUserId(id);
        }

        public async Task<List<Pet>> GetPetsByVetId(int id)
        {
            return await _petRepository.GetPetsByVetId(id);
        }

        public async Task DeletePet(Pet pet)
        {
            await _petRepository.DeletePet(pet);
        }

        public async Task DeleteUserPets(List<Pet> pets)
        {
            List<PetCard> petCards = new List<PetCard>();

            foreach (Pet pet in pets) 
            {
                petCards.Add(pet.PetCard);
            }

            await _petRepository.DeleteUserPets(pets);

            await _petCardRepository.DeleteUserPetsPetCards(petCards);
        }
    }
}