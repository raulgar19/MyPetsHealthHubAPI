using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;
using System.Linq;

namespace MyPetsHealthHubApi.Repositories
{
    public class PetCardRepository : IPetCardRepository
    {
        private readonly AppDbContext _context;

        public PetCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PetCard> AddPetCard(PetCard petCard)
        {
            _context.PetCards.AddAsync(petCard);
            await _context.SaveChangesAsync();
            return petCard;
        }

        public async Task<string> GetLastRegisterNumber()
        {
            return await _context.PetCards.OrderByDescending(pc => pc.Register).Select(pc => pc.Register).FirstOrDefaultAsync();
        }

        public async Task<PetCard> GetPetCard(int petCardId)
        {
            return await _context.PetCards.FirstOrDefaultAsync(pc => pc.Id == petCardId);
        }

        public async Task DeletePetCard(PetCard petCard)
        {
            _context.PetCards.Remove(petCard);
            await _context.SaveChangesAsync();
        }
    }
}