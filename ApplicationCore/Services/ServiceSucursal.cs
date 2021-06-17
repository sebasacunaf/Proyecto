using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceSucursal : IServiceSucursal
    {
        public IEnumerable<Sucursal> GetSucursals()
        {
            IRepositorySucursal repository = new RepositorySucursal();
            return repository.GetSucursals();
        }
    }
}
