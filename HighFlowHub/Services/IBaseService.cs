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
using System.Linq.Expressions;

/**
 * ========== BUSINESS LOGIC ==========
 */
namespace HighFlowHub.Services
{
    /// <summary>
    ///  Interface Shared Services
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public interface IBaseService<TEntity>
    {
        /// <summary>
        ///  Get All Item
        /// </summary>
        /// <returns>List of Items</returns>
        public Task<IEnumerable<TEntity>> GetAsync();

        /// <summary>
        ///  Get Items Per Page
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>List of Item per Page</returns>
        public Task<IEnumerable<TEntity>> GetAsync(int pageIndex, int pageSize);

        /// <summary>
        ///  Create Service
        /// </summary>
        /// <returns>New item</returns>
        public Task<TEntity> CreateAsync(TEntity entity);

        /// <summary>
        ///  Update Item
        /// </summary>
        /// <param name="entity">Update Entity</param>
        /// <returns>Updated Entity</returns>
        public Task<TEntity> UpdateAsync (TEntity entity);

        /// <summary>
        ///  Delete Entity
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>True if delete success</returns>
        public Task<bool> DeleteAsync(int id);
        
        /// <summary>
        ///  Search Item
        /// </summary>
        /// <param name="predictive">Search conditions</param>
        /// <returns>List result</returns>
        public Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predictive);
    }
}