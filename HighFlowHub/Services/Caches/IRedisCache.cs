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

using HighFlowHub.Models;

namespace HighFlowHub.Services.Caches
{
    /// <summary>
    ///  Redis Services Interface
    /// </summary>
    public interface IRedisCache
    {
        /// <summary>
        ///  Get Cache By Key
        /// </summary>
        /// <param name="redisKey">redis key</param>
        /// <typeparam name="T">value type</typeparam>
        /// <returns>Value type T</returns>
        // public Task<T?> GetCacheItem<T>(string redisKey) where T : BaseModel;

        public Task<T?> GetCache<T>(string redisKey);
        
        /// <summary>
        ///  Create new Cache by Key
        /// </summary>
        /// <param name="redisKey">redis key</param>
        /// <param name="obj">redis value object</param>
        /// <returns>None</returns>
        public Task CreateCache(string redisKey, object obj);
    }   
}