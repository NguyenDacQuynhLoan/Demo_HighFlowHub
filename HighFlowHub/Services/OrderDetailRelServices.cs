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
using HighFlowHub.Entites;

namespace HighFlowHub.Services
{
    public class OrderDetailRelServices : BaseService<OrderDetailRel>
    {
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="provider">Service provider</param>
        /// <param name="context">Project DB Context</param>
        public OrderDetailRelServices (DBContext context) : base (context)
        {
        }
    }
}