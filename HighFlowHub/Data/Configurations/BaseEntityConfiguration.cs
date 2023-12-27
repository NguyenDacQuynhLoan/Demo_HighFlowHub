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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HighFlowHub.Entites;

/**
 * ========== DATABASE CONFIGURATIONS ==========
 */
namespace HighFlowHub.Configurations
{
    /// <summary>
    ///  Shared Entity Configuration
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        ///  Default register primary key
        /// </summary>
        /// <param name="builder">Model builer entity</param>
        public virtual void Configure (EntityTypeBuilder<TEntity> builder)
        {
            var generateIdName = $"{typeof(TEntity).Name}Id";

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd()
                   .HasColumnName(generateIdName);
        }
    }
}