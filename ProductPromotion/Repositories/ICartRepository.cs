﻿using ProductPromotion.Entities;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int cartId, int cartItemId);
        Task ClearCart(string userName);
    }
}
