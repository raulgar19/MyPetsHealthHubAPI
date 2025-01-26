using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class VetUserService : IVetUserService
    {
        private readonly IVetUserRepository _vetUserRepository;

        public VetUserService(IVetUserRepository vetUserRepository)
        {
            _vetUserRepository = vetUserRepository;
        }

        public async Task<VetUser> VetLogin(string user, string password)
        {
            return await _vetUserRepository.VetLogin(user, password);
        }
    }
}