using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ProductPromotion.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Entities.Category> CategoryList { get; set; } = new List<Entities.Category>();

        public async Task<IActionResult> OnGetAsync()
        {
            CategoryList = await _productRepository.GetCategories();
            return Page();
        }
    }
}
