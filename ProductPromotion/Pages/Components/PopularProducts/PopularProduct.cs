using Microsoft.AspNetCore.Mvc;
using ProductPromotion.Repositories;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace ProductPromotion.Pages.Components.PopularProducts
{
    public class PopularProducts : ViewComponent
    {
        private readonly IProductRepository _productRepository;

        public PopularProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var productList = await _productRepository.GetProductListAsync();
            var countedProducts = productList.Take(count);

            return View(countedProducts);
        }
    }
}
