using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data.MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class VetUserRepository : IVetUserRepository
    {
        private readonly AppDbContext _context;

        public VetUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VetUser> VetLogin(string user, string password)
        {
            return await _context.VetUsers.FirstOrDefaultAsync(u => u.User == user && u.Password == password);
        }
    }
}