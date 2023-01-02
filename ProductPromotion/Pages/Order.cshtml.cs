using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ProductPromotion
{
    public class OrderModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public OrderModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Entities.Order> Orders { get; set; } = new List<Entities.Order>();

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _orderRepository.GetOrdersByUserName("test");

            return Page();
        }
    }
}
