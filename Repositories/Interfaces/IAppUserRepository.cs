using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> UserLogin(string email, string password);
    }
}