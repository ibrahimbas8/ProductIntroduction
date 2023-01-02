using ProductPromotion.Entities;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CheckOut(Order orderModel);
    }
}
