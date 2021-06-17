using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceGestion : IServiceGestion
    {
        public Gestion GetGestionByID(int id)
        {
            IRepositoryGestion repository = new RepositoryGestion();
            return repository.GetGestionByID(id);

        }

        public IEnumerable<Gestion> GetGestions()
        {
            IRepositoryGestion repository = new RepositoryGestion();
            return repository.GetGestions();
        }

        public IEnumerable<Gestion> GetGestionsByFecha(string fecha)
        {
            IRepositoryGestion repository = new RepositoryGestion();
            return repository.GetGestionsByFecha(fecha);
        }

        public IEnumerable<Gestion> GetGestionsByFechaAndTipo(string fecha, string tipo)
        {
            IRepositoryGestion repository = new RepositoryGestion();
            return repository.GetGestionsByFechaAndTipo(fecha, tipo);
        }

        public IEnumerable<Gestion> GetGestionsByTipoMovimiento(string tipo)
        {
            IRepositoryGestion repository = new RepositoryGestion();
            return repository.GetGestionsByTipoMovimiento(tipo);
        }
    }
}
