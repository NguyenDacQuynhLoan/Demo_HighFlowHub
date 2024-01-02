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
namespace HighFlowHub.Models
{
    /// <summary>
    ///  Order Model
    /// </summary>
    public class Order : BaseModel
    {
        public string OrderName { get; set; }

        public string OrderCode { get; set; }

        public string? Description { get; set; }
    }
}
