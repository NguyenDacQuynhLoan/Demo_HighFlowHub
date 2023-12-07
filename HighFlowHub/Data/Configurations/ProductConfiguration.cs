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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HighFlowHub.Entites;

namespace HighFlowHub.Configurations
{
    /// <summary>
    ///  Product Configuration
    /// </summary>
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure (EntityTypeBuilder<Product> builder)
        {
            base.Configure (builder);   

            builder.ToTable("product_tbl");
        }
    }
}