﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TietokantasovellusMvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HarjoitustietokantaEntities : DbContext
    {
        public HarjoitustietokantaEntities()
            : base("name=HarjoitustietokantaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Henkilot> Henkilot { get; set; }
        public virtual DbSet<Projektit> Projektit { get; set; }
        public virtual DbSet<Tunnit> Tunnit { get; set; }
    }
}