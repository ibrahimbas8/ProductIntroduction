using ProductPromotion.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductByNameAsync(string name);
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetCategories();
    }
}
