﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructure.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class INVENTARIOEntities : DbContext
    {
        public INVENTARIOEntities()
            : base("name=INVENTARIOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agente> Agente { get; set; }
        public virtual DbSet<Calzado> Calzado { get; set; }
        public virtual DbSet<CalzadoxSucursal> CalzadoxSucursal { get; set; }
        public virtual DbSet<DetalleMovimiento> DetalleMovimiento { get; set; }
        public virtual DbSet<Gestion> Gestion { get; set; }
        public virtual DbSet<GestionDetalle> GestionDetalle { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Tallas> Tallas { get; set; }
        public virtual DbSet<TipoGenero> TipoGenero { get; set; }
        public virtual DbSet<TipoMarca> TipoMarca { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}