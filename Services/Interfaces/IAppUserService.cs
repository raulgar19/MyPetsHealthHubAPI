using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUser> UserLogin(string email, string password);
    }
}