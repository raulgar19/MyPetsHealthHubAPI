using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletByUserId(int walletId);
    }
}
