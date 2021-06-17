//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Gestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gestion()
        {
            this.GestionDetalle = new HashSet<GestionDetalle>();
        }
    
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string IdTipoMovimiento { get; set; }
        public string IdDetalleMovimiento { get; set; }
        public string IdSucursal { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public string Fecha { get; set; }
    
        public virtual DetalleMovimiento DetalleMovimiento { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GestionDetalle> GestionDetalle { get; set; }
    }
}
