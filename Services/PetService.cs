using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
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
    }
}