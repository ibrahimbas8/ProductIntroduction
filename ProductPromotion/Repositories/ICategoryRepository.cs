using ProductPromotion.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
