using ProductPromotion.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CheckOut(Order orderModel);
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
