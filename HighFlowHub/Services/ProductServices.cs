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

namespace HighFlowHub.Services
{
    public class ProductServices : BaseService<Product>
    {
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="provider">Service provider</param>
        /// <param name="context">Project DB Context</param>
        public ProductServices (DBContext context) : base (context)
        {
        }
    }
}