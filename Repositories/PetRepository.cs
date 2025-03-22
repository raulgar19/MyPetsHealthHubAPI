using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AppDbContext _context;

        public PetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPet(Pet pet)
        {
            _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _context.Pets.Include(p => p.PetCard).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Pet>> GetPetsByUserId(int id)
        {
            return await _context.Pets.Where(p => p.AppUserId == id).Include(p => p.PetCard).ToListAsync();
        }

        public async Task<List<Pet>> GetPetsByVetId(int id)
        {
            return await _context.Pets.Where(p => p.VetId == id).ToListAsync();
        }

        public async Task UpdatePets(List<Pet> pets)
        {
            foreach (Pet pet in pets)
            {
                _context.Pets.Update(pet);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeletePet(Pet pet)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserPets(List<Pet> pets)
        {
            foreach (Pet pet in pets)
            {
                _context.Pets.Remove(pet);
            }

            await _context.SaveChangesAsync();
        }
    }
}