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

/**
 * ========== VALIDATION ==========
 */
namespace HighFlowHub.Controllers
{
    /// <summary>
    ///  Interface Shared Controller Methods 
    /// </summary>
    /// <typeparam name="TModel">Model</typeparam>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TServices">Entity Services</typeparam>
    public interface IBaseController<TModel,TEntity,TServices>
    {
        /// <summary>
        ///  Get List of Items
        /// </summary>
        public Task<IEnumerable<TModel>> GetAsync();

        /// <summary>
        ///  Get List Items per Page
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>List Items</returns>
        public Task<List<TEntity>> GetAsync(int pageIndex, int pageSize);

        /// <summary>
        ///  Create new model
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public Task<TModel> CreateAsync(TModel model);

        /// <summary>
        ///   Delete model
        /// </summary>
        /// <param name="id">Model ID</param>
        /// <returns>true if delete success</returns>
        public Task<bool> DeleteAsync(int id);
        
        /// <summary>
        ///  Update Items
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<TModel> UpdateAsync(TModel model);
    }
}