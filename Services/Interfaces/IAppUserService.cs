using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUser> GetUserById(int id);
        Task<AppUser> UserLogin(string email, string password);
    }
}