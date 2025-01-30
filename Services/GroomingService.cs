using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class GroomingService : IGroomingService
    {
        private readonly IGroomingRepository _groomingRepository;

        public GroomingService(IGroomingRepository groomingRepository)
        {
            _groomingRepository = groomingRepository;
        }

        public async Task<List<Grooming>> GetAll()
        {
            return await _groomingRepository.GetAll();
        }
    }
}