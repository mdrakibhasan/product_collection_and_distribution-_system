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
    
    public partial class UserGroup
    {
        public UserGroup()
        {
            this.UTL_USERINFO = new HashSet<UTL_USERINFO>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<short> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual ICollection<UTL_USERINFO> UTL_USERINFO { get; set; }
    }
}
