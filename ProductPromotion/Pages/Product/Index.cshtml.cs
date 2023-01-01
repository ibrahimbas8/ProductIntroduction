using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ProductPromotion.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Entities.Product> ProductList { get; set; } = new List<Entities.Product>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _productRepository.GetProductByNameAsync(SearchTerm);
            return Page();
        }
    }
}
