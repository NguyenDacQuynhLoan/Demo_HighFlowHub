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
using System.Linq.Expressions;

using HighFlowHub.Entites;
using HighFlowHub.Repositories;

/**
 * ========== BUSINESS LOGIC ==========
 */
namespace HighFlowHub.Services
{
    /// <summary>
    ///  Shared Services
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private BaseRepository<TEntity> _repository { get;}

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="context">DB Context</param>
        protected BaseService (DBContext context)
        {
            _repository = new BaseRepository<TEntity>(context);
        }
  
        /// <summary>
        ///  Get All Items
        /// </summary>
        /// <returns>List of Items</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync ()
        {   
            var result =  await _repository.GetAsync();
            return result.AsEnumerable();
        }

        /// <summary>
        ///  Get Items Per Page
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>List of Item per Page</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync(int pageIndex, int pageSize)
        {
            var result = await _repository.GetAsync();
            return result.Skip(pageSize*pageIndex).Take(pageSize).AsEnumerable();
        }

        /// <summary>
        ///  Create new Item
        /// </summary>
        /// <returns>New item</returns>
        public virtual async Task<TEntity> CreateAsync (TEntity entity)
        {   
            return await _repository.CreateAsync(entity);
        }
        
        /// <summary>
        ///  Update Product
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Updated Entity</returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
        
        /// <summary>
        ///  Delete Item
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>true if delete success</returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        /// <summary>
        ///  Search Items
        /// </summary>
        /// <param name="predictive">Search condition</param>
        /// <returns>List result</returns>
        public virtual async Task<IEnumerable<TEntity>> SearchAsync (Expression<Func<TEntity, bool>> predictive)
        {
            return await _repository.FindAsync(predictive);
        }
    }
}