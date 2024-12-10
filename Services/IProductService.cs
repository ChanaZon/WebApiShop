using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
    }
}