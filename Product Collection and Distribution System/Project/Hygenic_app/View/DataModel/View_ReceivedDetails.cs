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
    
    public partial class View_ReceivedDetails
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ItemCode { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> MstID { get; set; }
    }
}
