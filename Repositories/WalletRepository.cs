using MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyPetsHealthHubApi.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _context;

        public WalletRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }

        public async Task<Wallet> GetWalletByUserId(int id)
        {
            return await _context.AppUsers.Where(a => a.Id == id).Select(a => a.Wallet).FirstOrDefaultAsync();
        }

        public async Task UpdateWalletAsync(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();
        }
    }
}
