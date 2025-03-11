using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            return await _walletRepository.CreateWallet(wallet);
        }

        public async Task<Wallet> GetWalletByUserId(int id)
        {
            return await _walletRepository.GetWalletByUserId(id);
        }

        public async Task UpdateWallet(Wallet wallet)
        {
            await _walletRepository.UpdateWalletAsync(wallet);
        }
    }
}
