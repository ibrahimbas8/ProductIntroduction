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
        public IEnumerable<Entities.Category> CategoryList { get; set; } = new List<Entities.Category>();

        public async Task<IActionResult> OnGetAsync()
        {
            CategoryList = await _productRepository.GetCategories();
            return Page();
        }
    }
}
