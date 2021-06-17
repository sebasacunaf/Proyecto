using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTipoMovimiento : IServiceTipoMovimiento
    {
        public IEnumerable<TipoMovimiento> GetTipoMovimientos()
        {
            IRepositoryTipoMovimiento repository = new RepositoryTipoMovimiento();
            return repository.GetTipoMovimientos();
        }
    }
}
