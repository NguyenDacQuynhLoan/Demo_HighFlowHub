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
    ///  Redis Cache Services
    /// </summary>
    public class RedisServices :  IRedisCache
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
        public async Task<T?> GetCache<T>(string redisKey) where T: class
        {
            var productsRedis = await _redis.GetStringAsync(redisKey);
            return JsonConvert.DeserializeObject<T>(redisKey);
        }

        /// <summary>
        ///  Create new Cache by Key
        /// </summary>
        /// <param name="redisKey">redis key</param>
        /// <param name="obj">redis value object</param>
        /// <returns>None</returns>
        public async Task CreateCacheByString(string redisKey,object obj)
        {
            await _redis.SetStringAsync(redisKey, JsonConvert.SerializeObject(obj));
        }
    }
}