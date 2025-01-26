using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IVetUserRepository
    {
        Task<VetUser> VetLogin(string user, string password);
    }
}