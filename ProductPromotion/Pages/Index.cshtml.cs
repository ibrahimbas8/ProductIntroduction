using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProductPromotion.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPromotion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ;
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
