using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Entities;
using ProductPromotion.Repositories.Interfaces;
using System.Threading.Tasks;
using System;

namespace ProductPromotion
{
    public class CartModel : PageModel
    {
        private readonly ICartRepository _cartRepository;

        public CartModel(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Entities.Cart Cart { get; set; } = new Entities.Cart();
        public decimal TotalPrice { get; set; } = 0;

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _cartRepository.GetCartByUserName("test");
            CalculateTotalPrice(Cart);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            await _cartRepository.RemoveItem(cartId, cartItemId);
            return RedirectToPage();
        }

        private void CalculateTotalPrice(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                TotalPrice += item.Price * item.Quantity;
            }
        }
    }
}
