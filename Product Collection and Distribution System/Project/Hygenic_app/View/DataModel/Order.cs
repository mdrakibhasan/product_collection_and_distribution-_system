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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public long ID { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public Nullable<decimal> CashReceived { get; set; }
        public Nullable<decimal> CashRefund { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<short> PaymentMethodID { get; set; }
        public string PaymentMethodNumber { get; set; }
        public Nullable<long> CustomerID { get; set; }
        public Nullable<short> OrderStatusID { get; set; }
        public Nullable<short> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<short> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<decimal> Due { get; set; }
        public Nullable<int> BankID { get; set; }
        public string CheckORCardNo { get; set; }
        public Nullable<System.DateTime> CheckDate { get; set; }
        public string NameOfIssuer { get; set; }
        public string NameOnTheCard { get; set; }
        public Nullable<int> TypeOfCard { get; set; }
        public Nullable<int> UploadFlag { get; set; }
        public Nullable<int> NewInvoiceID { get; set; }
        public Nullable<int> BranchServerID { get; set; }
        public Nullable<int> DeleteBy { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public Nullable<int> ServiceBy { get; set; }
        public string MobileNo { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public Nullable<int> OfferTypeID { get; set; }
        public Nullable<int> OfferID { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
