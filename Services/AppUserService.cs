using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Models.RequestModels;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserService(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task CreateUser(AppUser user)
        {
            await _appUserRepository.CreateUser(user);
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _appUserRepository.GetUserById(id);
        }

        public async Task<List<AppUser>> GetUsersByVetId(int id)
        {
            return await _appUserRepository.GetUsersByVetId(id);
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await _appUserRepository.GetUserByEmail(email);
        }

        public async Task<Vet> GetVetByUserId(int userId)
        {
            return await _appUserRepository.GetVetByUserId(userId);
        }
    }

}