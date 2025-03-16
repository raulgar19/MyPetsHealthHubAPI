using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Models.RequestModels;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUser> GetUserById(int id);
        Task<List<AppUser>> GetUsersByVetId(int id);
        Task<AppUser> GetUserByEmail(string email);
        Task CreateUser(AppUser user);
        Task<Vet> GetVetByUserId(int userId);
        Task UpdateUser(AppUser appUser);
        Task DeleteUser(AppUser user);
    }
}