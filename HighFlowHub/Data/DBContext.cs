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
using HighFlowHub.Entites;

namespace HighFlowHub
{
    public class DBContext : DbContext
    {
        //protected IConfiguration _configuration;
        
        protected IServiceProvider _serviceProvider;

        public DBContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        ///  Constructor
        /// </summary>
        public DBContext(IServiceProvider serviceProvider, DbContextOptions options) : base(options)
        {
            //_configuration = serviceProvider.GetService<IConfiguration>( );
            _serviceProvider = serviceProvider;
        }
        
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
