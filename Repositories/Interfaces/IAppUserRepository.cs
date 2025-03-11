using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetUserById(int id);
        Task<List<AppUser>> GetUsersByVetId(int id);
        Task<AppUser> GetUserByEmail(string email);
        Task CreateUser(AppUser user);
        Task<Vet> GetVetByUserId(int userId);
        Task UpdateUser(AppUser appUser);
    }
}