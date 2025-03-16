using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IWalletService
    {
        Task<Wallet> CreateWallet(Wallet wallet);
        Task DeleteWallet(Wallet wallet);
        Task<Wallet> GetWalletById(int walletId);
        Task<Wallet> GetWalletByUserId(int id);
        Task UpdateWallet(Wallet wallet);
    }
}