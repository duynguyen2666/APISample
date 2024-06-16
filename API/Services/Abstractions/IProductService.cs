using API.Database;

namespace API.Services.Abstractions
{
    public interface IProductService
    {
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdatePriceAsync(int productId, int newPrice);
    }
}
