﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceTipoUsuario
    {
        IEnumerable<TipoUsuario> GetTipoUsuarios();
        TipoUsuario GetTipoUsuarioByID(int id);
    }
}
