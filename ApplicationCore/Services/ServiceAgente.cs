using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceAgente : IServiceAgente
    {
        public Agente GetAgenteByID(int id)
        {
            IRepositoryAgente repositoryAgente = new RepositoryAgente();
            return repositoryAgente.GetAgenteByID(id);
        }

        public IEnumerable<Agente> GetAgentes()
        {
            IRepositoryAgente repositoryAgente = new RepositoryAgente();
            return repositoryAgente.GetAgentes();
        }

        public IEnumerable<Agente> GetAgentesByProveedor(int id)
        {
            IRepositoryAgente repositoryAgente = new RepositoryAgente();
            return repositoryAgente.GetAgentesByProveedor(id);
        }
    }
}
