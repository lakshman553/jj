﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jeevanjyothi1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class jeevanjyothi_dbEntities : DbContext
    {
        public jeevanjyothi_dbEntities()
            : base("name=jeevanjyothi_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bloodgroup> bloodgroups { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<smsoutput> smsoutputs { get; set; }
        public virtual DbSet<requirement> requirements { get; set; }
    }
}
