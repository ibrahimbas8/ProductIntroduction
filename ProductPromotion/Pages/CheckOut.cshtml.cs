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
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public Entities.Order Order { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? cartId)
        {

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });
            return Page();
        }
    }
}
