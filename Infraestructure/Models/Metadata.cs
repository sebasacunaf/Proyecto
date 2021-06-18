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
            [Display(Name = "Cédula")]
            public int Id { get; set; }
        public string Nombre { get; set; }

            [Display(Name = "Teléfono")]
            public string Telefono { get; set; }

            [Display(Name = "Correo")]
            public string Correo { get; set; }

            [Display(Name = "Proveedor")]
            public Nullable<int> IdProveedor { get; set; }

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
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Marca")]
        public string NombreMarca { get; set; }
        [Display(Name = "Género")]
        public string IdGenero { get; set; }
        [Display(Name = "Talla")]
        public Nullable<int> IdTalla { get; set; }
        [Display(Name = "Precio Proveedor")]
        public Nullable<decimal> PrecioProv { get; set; }
        [Display(Name = "Precio de Venta")]
        public Nullable<decimal> PrecioVent { get; set; }

        [Display(Name = "Cantidad Mínima")]
        public Nullable<int> CantMin { get; set; }
        [Display(Name = "Cantidad Máxima")]
        public Nullable<int> CantMax { get; set; }
        [Display(Name = "Cantidad Total")]
        public Nullable<int> CantTotal { get; set; }
        public byte[] Foto { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
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
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }
        [Display(Name = "País")]
        public string Pais { get; set; }
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
