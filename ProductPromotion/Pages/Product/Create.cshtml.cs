using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductPromotion.Repositories;
using System.Threading.Tasks;
using System;

namespace ProductPromotion.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public CreateModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var categories = await _productRepository.GetCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Entities.Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product = await _productRepository.AddAsync(Product);
            return RedirectToPage("./Index");
        }
    }
}
