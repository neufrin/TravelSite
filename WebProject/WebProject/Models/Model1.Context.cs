﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class webprojectDBEntities : DbContext
    {
        public webprojectDBEntities()
            : base("name=webprojectDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COMMENT> COMMENT { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Ranking> Ranking { get; set; }
        public virtual DbSet<Travels> TravelsSet { get; set; }
    }
}
