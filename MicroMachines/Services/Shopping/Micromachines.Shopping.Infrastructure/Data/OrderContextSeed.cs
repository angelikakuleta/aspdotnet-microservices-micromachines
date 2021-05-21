using MicroMachines.Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMachines.Shopping.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetSampleOrders());
                await orderContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Order> GetSampleOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    Id = Guid.Parse("05559eb9-3653-4587-9b71-90953ef41d43"),
                    BuyerId = Guid.Parse("05559eb9-3653-4587-9b71-90953ef41d43"),
                    OrderDate = DateTime.Now,
                    TransactionId = Guid.Parse("70c5d2e9-9162-45c0-9006-6022cf9947df"),
                    Status = OrderStatus.Confirmed,
                    Address = new Address()
                    {
                        Id = Guid.Parse("0d28b11e-0f2f-4e3c-a788-1875cf4936ff"),
                        FistName = "Willie",
                        LastName = "Geier",
                        Email = "uhpjh3q5ieq@mail.net",
                        Street = "2578 Crestview Terrace",
                        City = "San Antonio",
                        State = "TX",
                        Country = "US",
                        ZipCode = "78205"
                    },
                    OrderItems = new List<OrderItem>()
                    {
                        new OrderItem 
                        { 
                            OrderId = Guid.Parse("05559eb9-3653-4587-9b71-90953ef41d43"),
                            ProductId = Guid.Parse("0654a8f9-cba6-4ec6-99e1-187d4a6e0a1b"),
                            ProductName = "Hot Wheels DC Comics Wonder Woman Vehicle", 
                            Quantity = 1, 
                            UnitPrice = 30.00M
                        },
                        new OrderItem 
                        { 
                            OrderId = Guid.Parse("05559eb9-3653-4587-9b71-90953ef41d43"),
                            ProductId = Guid.Parse("59edcce9-9002-4e1e-b120-d8122c5ba25d"), 
                            ProductName = "Monster Trucks Tiger Shark", 
                            Quantity = 2, 
                            UnitPrice = 12.50M
                        }
                    }
                }
            };
        }
    }
}
