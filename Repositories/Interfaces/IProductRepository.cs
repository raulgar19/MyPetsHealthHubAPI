using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByTypeId(int id);
    }
}