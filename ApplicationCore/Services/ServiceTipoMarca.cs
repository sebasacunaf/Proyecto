using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTipoMarca : IServiceTipoMarca
    {
        public IEnumerable<TipoMarca> GetTipoMarcas()
        {
            IRepositoryTipoMarca repository = new RepositoryTipoMarca();
            return repository.GetTipoMarcas();
        }
    }
}
