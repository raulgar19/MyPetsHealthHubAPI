using MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

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
    }
}