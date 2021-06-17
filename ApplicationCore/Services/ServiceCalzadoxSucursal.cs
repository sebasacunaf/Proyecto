using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceCalzadoxSucursal : IServiceCalzadoxSucursal
    {
        public IEnumerable<CalzadoxSucursal> GetCalzadoxSucursalBySucursal(string sucursal)
        {
            IRepositoryCalzadoxSucursal repository = new RepositoryCalzadoxSucursal();
            return repository.GetCalzadoxSucursalBySucursal(sucursal);
        }

        public IEnumerable<CalzadoxSucursal> GetSucursalByCalzado(int id)
        {
            IRepositoryCalzadoxSucursal repository = new RepositoryCalzadoxSucursal();
            return repository.GetSucursalByCalzado(id);
        }
    }
}
