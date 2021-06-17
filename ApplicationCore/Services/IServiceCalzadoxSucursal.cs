using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceCalzadoxSucursal
    {
        IEnumerable<CalzadoxSucursal> GetCalzadoxSucursalBySucursal(string sucursal);
        IEnumerable<CalzadoxSucursal> GetSucursalByCalzado(int id);
    }
}
