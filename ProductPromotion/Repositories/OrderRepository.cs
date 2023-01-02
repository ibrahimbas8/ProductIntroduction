using ProductPromotion.Entities;
using ProductPromotion.Repositories.Interfaces;
using System.Threading.Tasks;
using System;
using ProductPromotion.Data;

namespace ProductPromotion.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly Context _dbContext;

        public OrderRepository(Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Order> CheckOut(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
