﻿using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceProveedor : IServiceProveedor
    {
        public IEnumerable<Proveedor> GetProveedor()
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedor();
        }

        public Proveedor GetProveedorByID(int id)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedorByID(id);
        }

        public IEnumerable<Proveedor> GetProveedorByNombre(string nombre)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedorByNombre(nombre);
        }

        public IEnumerable<Proveedor> GetProveedores()
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.GetProveedores();
        }

        public Proveedor Save(Proveedor proveedor)
        {
            IRepositoryProveedor repository = new RepositoryProveedor();
            return repository.Save(proveedor);
        }
    }
}
