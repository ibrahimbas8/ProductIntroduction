using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProductPromotion
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public ProductDetailModel(IProductRepository productRepository, ICartRepository cartRepository)
        {
            _productRepository = productRepository ;
            _cartRepository = cartRepository ;
        }

        public Entities.Product Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            Product = await _productRepository.GetProductById(productId.Value);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _cartRepository.AddItem("test", productId, Quantity, Color);
            return RedirectToPage("Cart");
        }
    }
}
