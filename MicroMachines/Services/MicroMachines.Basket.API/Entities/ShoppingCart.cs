using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroMachines.Basket.API.Entities
{
    public class ShoppingCart
    {
        public Guid UserId { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart(Guid userId)
        {
            UserId = userId;
        }

        public decimal TotalPrice => Items.Sum(x => x.UnitPrice * x.Quantity);
    }
}
