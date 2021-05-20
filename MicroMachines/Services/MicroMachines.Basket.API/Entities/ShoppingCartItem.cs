using System;

namespace MicroMachines.Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}