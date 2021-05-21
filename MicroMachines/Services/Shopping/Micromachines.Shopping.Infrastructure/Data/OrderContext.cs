using Microsoft.EntityFrameworkCore;
using MicroMachines.Shopping.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace MicroMachines.Shopping.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(x => new { x.OrderId, x.ProductId });
        }
    }
}
