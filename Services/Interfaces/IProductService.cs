using MyPetsHealthHubApi.Models;

namespace MyPetsHealthHubApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsByTypeId(int id);
    }
}