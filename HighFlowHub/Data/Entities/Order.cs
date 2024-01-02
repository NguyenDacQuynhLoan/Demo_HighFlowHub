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
    ///  Order Entity
    /// </summary>
    public class Order : BaseEntity
    {
        public string OrderName { get; set; }

        public string OrderCode { get; set; }

        public string? Description { get; set; }

        public ICollection<OrderDetailRel> OrderDetailRel { get; set; }

        public Order ()
        {
            this.OrderDetailRel = new HashSet<OrderDetailRel>( );
        }
    }
}