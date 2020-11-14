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
    
    public partial class ProductReceivedMst
    {
        public ProductReceivedMst()
        {
            this.ProductReceivedDtls = new HashSet<ProductReceivedDtl>();
        }
    
        public int ID { get; set; }
        public Nullable<int> CollectorID { get; set; }
        public Nullable<System.DateTime> CollectDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> ReceivedAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public string CollectedCode { get; set; }
        public Nullable<int> AddBy { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> DeleteBy { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public string ReguestStatus { get; set; }
        public string CollectorName { get; set; }
        public string AgentCode { get; set; }
        public Nullable<int> AgentID { get; set; }
        public Nullable<decimal> LaberCost { get; set; }
        public Nullable<decimal> ShippingCost { get; set; }
        public Nullable<decimal> TotalQuantity { get; set; }
        public Nullable<int> CollectedMstID { get; set; }
    
        public virtual ICollection<ProductReceivedDtl> ProductReceivedDtls { get; set; }
    }
}
