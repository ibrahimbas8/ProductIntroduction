﻿
using ProductPromotion.Entities;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserName(string userName);
        Task AddItem(string userName, int productId, int quantity, string color);
        Task RemoveItem(int cartId, int cartItemId);
        Task ClearCart(string userName);
    }
}
