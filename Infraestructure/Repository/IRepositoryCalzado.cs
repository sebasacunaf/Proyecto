using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryCalzado
    {
        IEnumerable<Calzado> GetCalzados();
        Calzado GetCalzadoByID(int id);
        IEnumerable<Calzado> GetCalzadosByMarca(String marca);
        IEnumerable<Calzado> GetCalzadosByGenero(String genero);
        IEnumerable<Calzado> GetCalzadosByTalla(int talla);
    }
}
