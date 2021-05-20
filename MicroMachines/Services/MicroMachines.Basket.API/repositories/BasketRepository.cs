using MicroMachines.Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MicroMachines.Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;

        public BasketRepository(IDistributedCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<ShoppingCart> GetSingle(Guid userId)
        {
            var basket = await _cache.GetStringAsync(userId.ToString());
            if (string.IsNullOrEmpty(basket)) return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> Edit(ShoppingCart basket)
        {
            await _cache.SetStringAsync(basket.UserId.ToString(), JsonConvert.SerializeObject(basket));
            return await GetSingle(basket.UserId);
        }

        public async Task Delete(Guid userId)
        {
            await _cache.RemoveAsync(userId.ToString());
        }
    }
}
