//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace View.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public Stock()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public int ItemId { get; set; }
        public Nullable<int> InQuantity { get; set; }
        public Nullable<int> OutType { get; set; }
        public Nullable<int> OutQuantity { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string ItemCode { get; set; }
        public Nullable<decimal> ClosingStock { get; set; }
        public Nullable<decimal> ClosingAmount { get; set; }
        public Nullable<decimal> CostPrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public string Code { get; set; }
    
        public virtual ItemInfo ItemInfo { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
