using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceAgente
    {
        IEnumerable<Agente> GetAgentes();
        Agente GetAgenteByID(int id);

        IEnumerable<Agente> GetAgentesByProveedor(int id);
        Agente Save(Agente agente);
    }
}
