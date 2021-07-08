using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceCalzado
    {
        IEnumerable<Calzado> GetCalzados();
        Calzado GetCalzadoByID(int id);
        IEnumerable<Calzado> GetCalzadosByMarca(String marca);
        IEnumerable<Calzado> GetCalzadosByGenero(String genero);
        IEnumerable<Calzado> GetCalzadosByTalla(int talla);
        Calzado Save(Calzado calzado, TipoGenero tipoGenero, Tallas tallas, TipoMarca tipoMarca, CalzadoxSucursal[] calzadoxSucursal, Proveedor[] proveedores);
    }
}
