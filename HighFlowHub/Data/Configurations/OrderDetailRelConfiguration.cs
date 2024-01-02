// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author      
// ------------------------------------------------------------------------------------------
// 2024.1.2     Loan   
// ==========================================================================================
//
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HighFlowHub.Entites;

namespace HighFlowHub.Configurations
{
    /// <summary>
    ///  Order Detail Configuration
    /// </summary>
    public class OrderDetailRelConfiguration : BaseEntityConfiguration<OrderDetailRel>
    {
        public override void Configure(EntityTypeBuilder<OrderDetailRel> builder)
        {
            base.Configure(builder);

            builder.ToTable("order_prod_rel");

            builder.HasKey(e => new { e.ProductId, e.OrderId });

            builder.HasOne(e => e.Product)
                .WithMany(e => e.OrderDetailRel)
                .HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetailRel)
                .HasForeignKey(e => e.OrderId);
        }
    }
}
