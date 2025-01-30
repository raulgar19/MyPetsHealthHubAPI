using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class VetService : IVetService
    {
        private readonly IVetRepository _vetRepository;

        public VetService(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }

        public async Task<List<Vet>> GetAll()
        {
            return await _vetRepository.GetAll();
        }

        public async Task<Vet> GetUserById(int id)
        {
            return await _vetRepository.GetUserById(id);
        }
    }
}
