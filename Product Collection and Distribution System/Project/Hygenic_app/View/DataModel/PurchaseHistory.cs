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
    
    public partial class PurchaseHistory
    {
        public int ID { get; set; }
        public Nullable<int> PurchaseID { get; set; }
        public string Remarks { get; set; }
        public string StatusType { get; set; }
        public string StatusDescription { get; set; }
        public Nullable<int> AddBy { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> Updatedate { get; set; }
        public Nullable<int> DeleteBy { get; set; }
        public Nullable<System.DateTime> Deletedate { get; set; }
        public string PurchaseCode { get; set; }
        public Nullable<System.DateTime> PoDate { get; set; }
        public string ChallanNo { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> FarmerID { get; set; }
        public string FarmerName { get; set; }
        public string FarmerMobile { get; set; }
    }
}
