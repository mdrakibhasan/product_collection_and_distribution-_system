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
    
    public partial class COUNTRY_INFO
    {
        public COUNTRY_INFO()
        {
            this.FarmerInfoes = new HashSet<FarmerInfo>();
        }
    
        public int COUNTRY_CODE { get; set; }
        public string COUNTRY_ABVR { get; set; }
        public string COUNTRY_DESC { get; set; }
    
        public virtual ICollection<FarmerInfo> FarmerInfoes { get; set; }
    }
}
