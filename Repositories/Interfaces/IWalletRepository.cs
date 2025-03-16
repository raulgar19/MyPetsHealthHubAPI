using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet> CreateWallet(Wallet wallet);
        Task DeleteWallet(Wallet wallet);
        Task<Wallet> GetWalletById(int walletId);
        Task<Wallet> GetWalletByUserId(int id);
        Task UpdateWalletAsync(Wallet wallet);
    }
}