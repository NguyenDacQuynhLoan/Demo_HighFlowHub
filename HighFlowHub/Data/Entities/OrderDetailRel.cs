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
namespace HighFlowHub.Entites
{
    /// <summary>
    ///  Order Detail Entity
    /// </summary>
    public class OrderDetailRel : BaseEntity
    {
        public uint ProductId { get; set; }

        public Product? Product { get; set; }

        public uint OrderId { get; set; }

        public Order? Order { get; set; }
    }
}