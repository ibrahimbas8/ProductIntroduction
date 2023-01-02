using System.Collections.Generic;

namespace ProductPromotion.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
