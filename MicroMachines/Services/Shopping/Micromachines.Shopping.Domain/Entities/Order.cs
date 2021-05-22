using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroMachines.Shopping.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.UtcNow;
            Status = OrderStatus.Pending;
            OrderItems = new List<OrderItem>();
        }

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RealisationDate { get; set; }
        public Guid BuyerId { get; set; }
        public Address Address { get; set; }       
        public Guid? TransactionId { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }

        public decimal TotalPrice => OrderItems.Sum(x => x.UnitPrice * x.Quantity);
    }

    public enum OrderStatus { Pending, Denied, Confirmed, Cancelled }
}
