using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ProductPromotion
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public ProductDetailModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Entities.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            Product = await _productRepository.GetProductByIdAsync(productId.Value);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
