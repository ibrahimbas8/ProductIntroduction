using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPromotion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Entities.Product> ProductList { get; set; } = new List<Entities.Product>();

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _productRepository.GetProductByNameAsync(SearchTerm);
            return Page();
        }
    }
}
