using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories;
using System.Threading.Tasks;
using System;

namespace ProductPromotion.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DetailsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
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
