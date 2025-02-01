using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data.MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;

        public AppUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<AppUser>> GetUsersByVetId(int id)
        {
            return await _context.AppUsers.Where(u => u.VetId == id).ToListAsync();
        }

        public async Task<AppUser> UserLogin(string email, string password)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}