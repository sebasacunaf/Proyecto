﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceGestion
    {
        IEnumerable<Gestion> GetGestions();
        IEnumerable<Gestion> GetGestionsByTipoMovimiento(string tipo);
        Gestion GetGestionByID(int id);
        IEnumerable<Gestion> GetGestionsByFecha(string fecha);
        IEnumerable<Gestion> GetGestionsByFechaAndTipo(string fecha, string tipo);
    }
}
