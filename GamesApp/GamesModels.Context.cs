//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamesApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WypozyczalniaGierEntities : DbContext
    {
        public WypozyczalniaGierEntities()
            : base("name=WypozyczalniaGierEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gra> Gras { get; set; }
        public virtual DbSet<Klient> Klients { get; set; }
        public virtual DbSet<Sklep> Skleps { get; set; }
        public virtual DbSet<Sprzedawca> Sprzedawcas { get; set; }
    }
}
