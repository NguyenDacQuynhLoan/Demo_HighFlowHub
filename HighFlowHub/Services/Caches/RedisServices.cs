// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author          EditDate    EditBy
// ------------------------------------------------------------------------------------------
// 2023.11.1   Loan            2023.12.27    Loan    
// ==========================================================================================
//
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace HighFlowHub.Services.Caches
{
    /// <summary>
    ///  Cache List Keys
    /// </summary>
    public static class CacheList
    {
        public const string ProductList = "product-list";

        public const string ProductItem = "prod";
    }
    
    /// <summary>
    ///  Redis Cache Services
    /// </summary>
    public class RedisServices:  IRedisCache
    {
        private readonly IDistributedCache _redis;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="redis">Redis Cache Distribute</param>
        public RedisServices(IDistributedCache redis)
        {
            _redis = redis;
        }

        /// <summary>
        ///  Get Cache By Key
        /// </summary>
        /// <param name="redisKey">redis key</param>
        /// <typeparam name="T">value type</typeparam>
        /// <returns>Value type T</returns>
        public async Task<T?> GetCache<T>(string redisKey)
        {
            var productsRedis = await _redis.GetStringAsync(redisKey);
            return string.IsNullOrEmpty(productsRedis)
                ? default
                : JsonConvert.DeserializeObject<T>(productsRedis);
        }

        /// <summary>
        ///  Create new Cache by Key
        /// </summary>
        /// <param name="redisKey">redis key</param>
        /// <param name="obj">redis value object</param>
        /// <returns>None</returns>
        public async Task CreateCache(string redisKey,object obj)
        {
            await _redis.SetStringAsync(redisKey, JsonConvert.SerializeObject(obj));
        }
    }
}