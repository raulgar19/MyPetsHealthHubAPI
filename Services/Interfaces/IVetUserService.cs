using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IVetUserService
    {
        Task<VetUser> VetLogin(string user, string password);
    }
}