// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author      
// ------------------------------------------------------------------------------------------
// 2023.10.23   Loan   
// ==========================================================================================
//

using HighFlowHub.Entites;
using HighFlowHub.Models;
using HighFlowHub.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

public static class CacheList
{
    public const string ProductList = "product-list";

    public const string ProductItem = "prod";
}

/**
 * ========== VALIDATION ==========
 */
namespace HighFlowHub.Controllers
{
    /// <summary>
    ///  Shared Controller Methods
    /// </summary>
    /// <typeparam name="TModel">Model</typeparam>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TServices">Entity Services</typeparam>
    public class BaseController<TModel, TEntity, TServices> : ControllerBase
        ,IBaseController<TModel, TEntity, TServices>
        where TModel : BaseModel, new()
        where TEntity : BaseEntity, new()
        where TServices : IBaseService<TEntity>
    {
        private IBaseService<TEntity> _service { get; set; }
        
        private IDistributedCache _redis;

        /// <summary>
        ///  Constructor
        /// </summary>
        public BaseController(IBaseService<TEntity> services)
        {
            _service = services;
        }
        
        /// <summary>
        ///  Get List of Model items
        /// </summary>
        /// <returns>List Model Items</returns>
        [NonAction]
        public virtual async Task<IEnumerable<TModel>> GetAsync()
        {
            var entityList = await _service.GetAsync();
            var modelList = entityList.Select(item => item.MapTo<TModel>());
            return modelList;
        }

        /// <summary>
        ///  Get List Items per Page
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>List Items</returns>
        [NonAction]
        public virtual async Task<List<TEntity>> GetAsync(int pageIndex, int pageSize)
        {
            var result = await _service.GetAsync(pageIndex, pageSize);
            return result.ToList();
        }
    
        /// <summary>
        ///  Create New Model
        /// </summary>
        /// <param name="model">Type Model</param>
        /// <returns>New model</returns>
        [NonAction]
        public virtual async Task<TModel> CreateAsync(TModel model)
        {
            var newEntity = model.MapTo<TEntity>();
            var createdEntity = await _service.CreateAsync(newEntity);
            return createdEntity == null ? null : model;
        }

        /// <summary>
        ///  Delete model
        /// </summary>
        /// <param name="id">Model Id</param>
        /// <returns></returns>
        [NonAction]
        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _service.DeleteAsync(id);
        }

        /// <summary>
        ///  Update model
        /// </summary>
        [NonAction]
        public virtual async Task<TModel> UpdateAsync(TModel model)
        {
            var newEntity = model.MapTo<TEntity>();
            var updatedModel = await _service.UpdateAsync(newEntity);
            return updatedModel == null ? null : model;
        }
    }
}