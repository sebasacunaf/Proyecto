using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceDetalleMoviemiento : IServiceDetalleMovimiento
    {
        public IEnumerable<DetalleMovimiento> GetDetalleMovimientosByTipo(string tipo)
        {
            IRepositoryDetalleMovimiento repository = new RepositoryDetalleMovimiento();
            return repository.GetDetalleMovimientosByTipo(tipo);
        }
    }
}
