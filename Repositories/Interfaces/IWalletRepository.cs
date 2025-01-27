using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletById(int id);
        Task UpdateWalletAsync(Wallet wallet);
    }
}