using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        public IEnumerable<TipoUsuario> GetTipoUsuarios()
        {
            IEnumerable<TipoUsuario> lista = null;
            try
            {
                IServiceTipoUsuario _SeviceTU = new ServiceTipoUsuario();
                lista = _SeviceTU.GetTipoUsuarios();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return lista;
        }
        public TipoUsuario GetTipoUsuariosbyID(int? id)
        {
            TipoUsuario tipousuario= null;
            try
            {
                IServiceTipoUsuario _SeviceTU = new ServiceTipoUsuario();
                tipousuario = _SeviceTU.GetTipoUsuarioByID(1);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return tipousuario;
        }
    }
}