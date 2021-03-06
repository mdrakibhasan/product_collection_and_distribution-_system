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
    
    public partial class ItemPurchaseMst
    {
        public ItemPurchaseMst()
        {
            this.ItemPurchaseDtls = new HashSet<ItemPurchaseDtl>();
        }
    
        public int ID { get; set; }
        public string GRN { get; set; }
        public Nullable<System.DateTime> ReceivedDate { get; set; }
        public string PO { get; set; }
        public Nullable<System.DateTime> PODate { get; set; }
        public string ChallanNo { get; set; }
        public Nullable<System.DateTime> ChallanDate { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string Currency { get; set; }
        public Nullable<short> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<short> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> carriage_charge { get; set; }
        public Nullable<decimal> labure_charge { get; set; }
        public Nullable<int> MST_Excel { get; set; }
        public string SupplierMobileNo { get; set; }
        public string Satatus { get; set; }
    
        public virtual FarmerInfo FarmerInfo { get; set; }
        public virtual ICollection<ItemPurchaseDtl> ItemPurchaseDtls { get; set; }
    }
}
