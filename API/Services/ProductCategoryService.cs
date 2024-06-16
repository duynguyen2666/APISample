using API.Database;
using API.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly APIDbContext _dbContext;

        public ProductCategoryService(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(ProductCategory productCategory)
        {
            _dbContext.ProductCategories.Add(productCategory);
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public Task<List<ProductCategory>> GetAllAsync()
        {
            return _dbContext.ProductCategories.ToListAsync();
        }

        public Task<List<ProductCategory>> GetAllWithAssociateDataAsync()
        {
            return _dbContext.ProductCategories.Include(e => e.Products).ToListAsync();
        }

        public Task<ProductCategory?> GetByIdAsync(int id)
        {
            return _dbContext.ProductCategories.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<ProductCategory?> GetByNameAsync(string name)
        {
            return _dbContext.ProductCategories.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<bool> UpdateProductCategoryNameAsync(int id, string productCateogryName)
        {
            var category = await GetByIdAsync(id);
            if(category == null)
            {
                return false;
            }
            category.Name = productCateogryName;
            _dbContext.ProductCategories.Update(category);
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}
