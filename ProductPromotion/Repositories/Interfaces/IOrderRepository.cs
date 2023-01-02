using ProductPromotion.Entities;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CheckOut(Order orderModel);
    }
}
