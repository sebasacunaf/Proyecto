using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
        internal partial class AgenteMetaData
        {
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Cédula")]
            public int Id { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [StringLength(8, ErrorMessage = "{0} no tiene formato válido")]
        [Display(Name = "Teléfono")]
            public string Telefono { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [EmailAddress(ErrorMessage = "Dirección de correo electrónico inválida")]
        [Display(Name = "Correo")]
            public string Correo { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Proveedor")]
            public Nullable<int> IdProveedor { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Estado")]
            public int Estado { get; set; }
        }
    internal partial class GestiónMetaData
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Movimiento")]
        public string IdTipoMovimiento { get; set; }

        [Display(Name = "Detalle")]
        public string IdDetalleMovimiento { get; set; }

        [Display(Name = "Sucursal")]
        public string IdSucursal { get; set; }

        [Display(Name = "Proveedor")]
        public Nullable<int> IdProveedor { get; set; }

        [Display(Name = "Fecha")]
        public string Fecha { get; set; }
    }
    internal partial class GestionDetalleMetaData
    {
        [Display(Name = "Código Gestión")]
        public int IdGestion { get; set; }
        [Display(Name = "Código Calzado")]
        public int IdCalzado { get; set; }
        public int Cantidad { get; set; }

    }
    internal partial class CalzadoMetaData
    {
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Código")]
        public int Id { get; set; }
       [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Marca")]
        public string NombreMarca { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Género")]
        public string IdGenero { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Talla")]
        public Nullable<int> IdTalla { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Precio Proveedor")]
        public Nullable<decimal> PrecioProv { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Precio de Venta")]
        public Nullable<decimal> PrecioVent { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Cantidad Mínima")]
        public Nullable<int> CantMin { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Cantidad Máxima")]
        public Nullable<int> CantMax { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Cantidad Total")]
        public Nullable<int> CantTotal { get; set; }
        public byte[] Foto { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        //[Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Tipo Género")]
        public virtual TipoGenero TipoGenero { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Sucursales")]
        public virtual ICollection<CalzadoxSucursal> CalzadoxSucursal { get; set; }
    }
    internal partial class CalzadoxSucursalMetaData
    {
        [Display(Name = "Sucursal")]
        public string IdSucursal { get; set; }
        [Display(Name = "Código Calzado")]
        public int IdCalzado { get; set; }
        public int Cantidad { get; set; }
    }

    internal partial class ProveedorMetaData
    {
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "País")]
        public string Pais { get; set; }
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Estado { get; set; }

    }

    internal partial class UsuarioMetaData
    {
        [Display(Name = "Código Usuario")]
        public int IdTipo { get; set; }
        [Display(Name = "Identificación")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }
        [Display(Name = "Contraseña")]
        public string Contrasenna { get; set; }
        public string Estado { get; set; }
    }

}
