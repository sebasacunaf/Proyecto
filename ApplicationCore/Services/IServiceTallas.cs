using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceTallas
    {
        IEnumerable<Tallas> GetTallas(string descripcion);
        Tallas GetTallasByID(int id);
    }
}
