using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories.Interfaces;
using System.Threading.Tasks;
using System;

namespace ProductPromotion
{
    public class CheckOutModel : PageModel
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;

        public CheckOutModel(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        [BindProperty]
        public Entities.Order Order { get; set; }

        [BindProperty]
        public Entities.Cart Cart { get; set; } = new Entities.Cart();

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _cartRepository.GetCartByUserName("test");
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            Cart = await _cartRepository.GetCartByUserName("test");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = "test";
            Order.TotalPrice = Cart.TotalPrice;

            await _orderRepository.CheckOut(Order);
            await _cartRepository.ClearCart("test");

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}
