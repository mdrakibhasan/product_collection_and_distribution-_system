//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductReceivedDtl
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> MstID { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> UOMID { get; set; }
        public Nullable<int> AddBy { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> DeleteBy { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
    
        public virtual ProductReceivedMst ProductReceivedMst { get; set; }
    }
}