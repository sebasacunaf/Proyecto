using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryCalzadoxSucursal
    {
        IEnumerable<CalzadoxSucursal> GetCalzadoxSucursalBySucursal(string sucursal);
        IEnumerable<CalzadoxSucursal> GetSucursalByCalzado(int id);
    }
}
