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
    
    public partial class OrderDetail
    {
        public long ID { get; set; }
        public Nullable<long> OrderID { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<short> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<short> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<decimal> ReturnQuantity { get; set; }
        public Nullable<int> UploadFlag { get; set; }
        public Nullable<decimal> PvUnitPrice { get; set; }
        public Nullable<decimal> ChangeQty { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> DeleteBy { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
