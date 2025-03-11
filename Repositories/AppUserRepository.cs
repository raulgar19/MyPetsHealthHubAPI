using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data;
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

        public async Task CreateUser(AppUser user)
        {
            _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<AppUser>> GetUsersByVetId(int id)
        {
            return await _context.AppUsers.Where(u => u.VetId == id).ToListAsync();
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Vet> GetVetByUserId(int userId)
        {
            return await _context.AppUsers.Where(u => u.Id == userId).Select(u => u.Vet).FirstOrDefaultAsync();
        }

        public async Task UpdateUser(AppUser appUser)
        {
            _context.AppUsers.Update(appUser);
            await _context.SaveChangesAsync();
        }
    }
}