using API.Database;

namespace API.Services.Abstractions
{
    public interface IProductCategoryService
    {
        Task<ProductCategory?> GetByIdAsync(int id);
        Task<ProductCategory?> GetByNameAsync(string name);
        Task<List<ProductCategory>> GetAllAsync();
        Task<List<ProductCategory>> GetAllWithAssociateDataAsync();
        Task<bool> AddAsync(ProductCategory productCategory);
        Task<bool> UpdateProductCategoryNameAsync(int id, string productCateogryName);
    }
}
