using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTallas : IServiceTallas
    {
        public IEnumerable<Tallas> GetTallas()
        {
            IRepositoryTallas repository = new RepositoryTallas();
            return repository.GetTallas();
        }

        public Tallas GetTallasByID(int id)
        {
            IRepositoryTallas repository = new RepositoryTallas();
            return repository.GetTallasByID(id);
        }
    }
}
