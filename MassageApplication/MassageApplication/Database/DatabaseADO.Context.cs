﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MassageApplication.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Massage_BookingEntities : DbContext
    {
        public Massage_BookingEntities()
            : base("name=Massage_BookingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Massage_Days> Massage_Days { get; set; }
        public virtual DbSet<Massage_Slots> Massage_Slots { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
