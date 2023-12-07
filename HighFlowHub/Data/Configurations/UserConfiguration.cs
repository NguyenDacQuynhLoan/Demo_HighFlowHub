﻿// ==========================================================================================
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HighFlowHub.Configurations
{
    /// <summary>
    ///  User Configuration
    /// </summary>
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user_tbl");
        }
    }
}
