using MyPetsHealthHubApi.Data.MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _context;

        public WalletRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet> GetWalletById(int id)
        {
            return _context.Wallets.FirstOrDefault(w => w.Id == id);
        }

        public async Task UpdateWalletAsync(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();
        }
    }
}