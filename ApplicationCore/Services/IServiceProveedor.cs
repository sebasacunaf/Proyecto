using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
   public  interface IServiceProveedor
    {
        IEnumerable<Proveedor> GetProveedorByNombre(String nombre);
        IEnumerable<Proveedor> GetProveedor();
        IEnumerable<Proveedor> GetProveedores();
        Proveedor GetProveedorByID(int id);
        Proveedor Save(Proveedor proveedor);
    }
}
