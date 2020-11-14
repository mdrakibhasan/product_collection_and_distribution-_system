﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FarmerInfo> FarmerInfoes { get; set; }
        public virtual DbSet<ItemInfo> ItemInfoes { get; set; }
        public virtual DbSet<ProductCollectedDtl> ProductCollectedDtls { get; set; }
        public virtual DbSet<ProductCollectedMst> ProductCollectedMsts { get; set; }
        public virtual DbSet<ProductReceivedDtl> ProductReceivedDtls { get; set; }
        public virtual DbSet<ProductReceivedMst> ProductReceivedMsts { get; set; }
        public virtual DbSet<SalaryPaymentDtl> SalaryPaymentDtls { get; set; }
        public virtual DbSet<SalaryPaymentMst> SalaryPaymentMsts { get; set; }
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
        public virtual DbSet<SalesMaster> SalesMasters { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<UOM> UOMs { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UTL_USERINFO> UTL_USERINFO { get; set; }
        public virtual DbSet<DISTRICTINFO> DISTRICTINFOes { get; set; }
        public virtual DbSet<DIVISION_CODE> DIVISION_CODE { get; set; }
        public virtual DbSet<THANAINFO> THANAINFOes { get; set; }
        public virtual DbSet<UTL_MODULES> UTL_MODULES { get; set; }
        public virtual DbSet<UTL_USERGRANT> UTL_USERGRANT { get; set; }
    }
}