using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetUserById(int id);
        Task<List<AppUser>> GetUsersByVetId(int id);
        Task<AppUser> UserLogin(string email, string password);
    }
}