using API.Database;
using API.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly APIDbContext _dbContext;
        public ProductService(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _dbContext.Products.ToListAsync();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return _dbContext.Products.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdatePriceAsync(int productId, int newPrice)
        {
            var product = await GetByIdAsync(productId);
            if(product is null)
            {
                return;
            }

            product.Price = newPrice;
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
