using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceGestionDetalle : IServiceGestionDetalle
    {
        public IEnumerable<GestionDetalle> GetGestionDetallesByIDGestion(int id)
        {
            IRepositoryGestionDetalle repository = new RepositoryGestionDetalle();
            return repository.GetGestionDetallesByIDGestion(id);
        }
    }
}
