using Microsoft.EntityFrameworkCore;
using MyPetsHealthHubApi.Data;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Repositories.Interfaces;

namespace MyPetsHealthHubApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsByTypeId(int id)
        {
            return await _context.Products
                .Where(p => p.ProductTypeId == id)
                .ToListAsync();
        }
    }
}