using ProductPromotion.Entities;
using ProductPromotion.Repositories.Interfaces;
using System.Threading.Tasks;
using System;
using ProductPromotion.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductPromotion.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly Context _dbContext;

        public OrderRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> CheckOut(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                            .Where(o => o.UserName == userName)
                            .ToListAsync();

            return orderList;
        }
    }
}
