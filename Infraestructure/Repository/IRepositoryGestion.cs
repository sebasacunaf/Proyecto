using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryGestion
    {
        IEnumerable<Gestion> GetGestions();
        IEnumerable<Gestion> GetGestionsByEntrada();
        IEnumerable<Gestion> GetGestionsBySalida();

        Gestion GetGestionByID(int id);
        IEnumerable<Gestion> GetGestionsByFecha(string fecha);
        IEnumerable<Gestion> GetGestionsByFechaAndTipo(string fecha, string tipo);

    }
}
