// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author          EditDate    EditBy
// ------------------------------------------------------------------------------------------
// 2023.11.1   Loan            2023.11.1    Loan    
// ==========================================================================================
//
using System.Linq.Expressions;
using HighFlowHub.Entites;

namespace HighFlowHub.Repositories
{
    /// <summary>
    ///  Interface Shared Repository
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        /// <summary>
        ///  Get all items of Entity
        /// </summary>
        /// <returns>Item query</returns>
        public Task<IQueryable<TEntity>> GetAsync ();

        /// <summary>
        ///  Get Item by Id
        /// </summary>
        /// <param name="id">Item Id</param>
        /// <returns>Item of Entity</returns>
        public Task<IQueryable<TEntity>> GetItemByIdAsync (int id);

        /// <summary>
        ///  Find entity 
        ///  </summary>
        /// <param name="predicate">Query condition</param>
        /// <returns>Found entity</returns>
        public Task<IQueryable<TEntity>> FindAsync (Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///  Create entity
        /// </summary>
        /// <param name="item">new entity</param>
        /// <returns>New entity</returns>
        public Task<TEntity> CreateAsync (TEntity item);

        /// <summary>
        ///  Update entity
        /// </summary>
        /// <param name="item">detect entity</param>
        /// <returns>updated entity</returns>
        public Task<TEntity> UpdateAsync (TEntity item);

        /// <summary>      
        ///  Delete Item
        /// </summary>
        /// <param name="Id">Delete Item Id</param>
        /// <returns>true if deleted</returns>
        public Task<bool> DeleteAsync (int Id);
    }
}