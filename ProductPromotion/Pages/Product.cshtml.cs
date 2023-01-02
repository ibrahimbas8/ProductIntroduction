using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPromotion
{
    public class ProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public ProductModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Entities.Category> CategoryList { get; set; } = new List<Entities.Category>();
        public IEnumerable<Entities.Product> ProductList { get; set; } = new List<Entities.Product>();

        public async Task<IActionResult> OnGetAsync(int? categoryId)
        {
            CategoryList = await _productRepository.GetCategories();
            ProductList = await _productRepository.GetProductByNameAsync(string.Empty);

            return Page();

        }
    }
}
