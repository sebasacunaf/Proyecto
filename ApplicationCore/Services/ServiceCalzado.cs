using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceCalzado : IServiceCalzado
    {
        public Calzado Save(Calzado calzado, TipoGenero tipoGenero, Tallas tallas, TipoMarca tipoMarca, CalzadoxSucursal[] calzadoxSucursal, Proveedor[] proveedores)
        {
            IRepositoryCalzado repository = new RepositoryCalzado();
            return repository.Save(calzado, tipoGenero, tallas, tipoMarca, calzadoxSucursal, proveedores);
        }
        public Calzado GetCalzadoByID(int id)
        {
            IRepositoryCalzado repository = new RepositoryCalzado();
            return repository.GetCalzadoByID(id);
        }

        public IEnumerable<Calzado> GetCalzados()
        {
            IRepositoryCalzado repository = new RepositoryCalzado();
            return repository.GetCalzados();
        }

        public IEnumerable<Calzado> GetCalzadosByGenero(string genero)
        {
            IRepositoryCalzado repository = new RepositoryCalzado();
            return repository.GetCalzadosByGenero(genero);
        }

        public IEnumerable<Calzado> GetCalzadosByMarca(string marca)
        {
            IRepositoryCalzado repository = new RepositoryCalzado();
            return repository.GetCalzadosByMarca(marca);
        }

        public IEnumerable<Calzado> GetCalzadosByTalla(int talla)
        {
            IRepositoryCalzado repository = new RepositoryCalzado();
            return repository.GetCalzadosByTalla(talla);
        }

    }
}
