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
namespace HighFlowHub.Models
{
    /// <summary>
    ///  Product Model
    /// </summary>
    public class Product : BaseModel
    {
        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Price { get; set; }
        
        public DateTime CreateDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsDiscount { get; set; }

        public decimal? DiscountPercent { get; set; }
    }
}
