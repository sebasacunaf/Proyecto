using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTipoGenero : IServiceTipoGenero
    {
        public IEnumerable<TipoGenero> GetTipoGeneros()
        {
            IRepositoryTipoGenero repository = new RepositoryTipoGenero();
            return repository.GetTipoGeneros();
        }
    }
}
