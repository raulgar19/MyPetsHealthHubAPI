using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IWalletService
    {
        Task<Wallet> CreateWallet(Wallet wallet);
        Task<Wallet> GetWalletById(int id);
        Task UpdateWallet(Wallet wallet);
    }
}