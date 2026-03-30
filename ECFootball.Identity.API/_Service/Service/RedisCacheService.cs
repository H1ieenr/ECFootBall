
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;


namespace ECFootball.Identity.API._Service.Service
{
    public class RedisCacheService(IDistributedCache cache)
    {
        public async Task SetCacheAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var options = new DistributedCacheEntryOptions();

            if (expiration.HasValue)
            {
                options.SetAbsoluteExpiration(expiration.Value);
            }
            else
            {
                options.SetAbsoluteExpiration(TimeSpan.FromDays(30));
            }

            var jsonData = JsonSerializer.Serialize(value);
            await cache.SetStringAsync(key, jsonData, options);
        }

        public async Task<T?> GetCacheAsync<T>(string key)
        {
            var jsonData = await cache.GetStringAsync(key);
            return jsonData == null ? default : JsonSerializer.Deserialize<T>(jsonData);
        }

    }
}