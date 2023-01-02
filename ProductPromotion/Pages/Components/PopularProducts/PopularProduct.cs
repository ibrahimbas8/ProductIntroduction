using Microsoft.AspNetCore.Mvc;
using ProductPromotion.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

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
            var productList = await _productRepository.GetProducts();
            var countedProducts = productList.Take(count);

            return View(countedProducts);
        }
    }
}
