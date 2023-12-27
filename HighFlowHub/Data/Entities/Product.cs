// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author          EditDate    EditBy
// ------------------------------------------------------------------------------------------
// 2023.11.1   Loan            2023.11.1    Loan    
// ==========================================================================================
//
namespace HighFlowHub.Entites
{
    /// <summary>
    ///  Product Entity
    /// </summary>
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsDiscount { get; set; }

        public decimal? DiscountPercent { get; set; }
    }
}