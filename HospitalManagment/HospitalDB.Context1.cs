﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManagment
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HospitalEntities : DbContext
    {
        public HospitalEntities()
            : base("name=HospitalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonDetail> PersonDetails { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<TypeofCheckUp> TypeofCheckUps { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<MedcineName> MedcineNames { get; set; }
        public DbSet<TypeOfMedcine> TypeOfMedcines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<OPD> OPDs { get; set; }
        public DbSet<Investigation> Investigations { get; set; }
        public DbSet<testException> testExceptions { get; set; }
    }
}
