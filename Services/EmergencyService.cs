using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class EmergencyService : IEmergencyService
    {
        private readonly IEmergencyRepository _emergencyRepository;

        public EmergencyService(IEmergencyRepository emergencyRepository)
        {
            _emergencyRepository = emergencyRepository;
        }

        public async Task<List<Emergency>> GetAll()
        {
            return await _emergencyRepository.GetAll();
        }
    }
}