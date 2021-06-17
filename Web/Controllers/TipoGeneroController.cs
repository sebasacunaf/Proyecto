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
    public class TipoGeneroController : Controller
    {
        // GET: TipoGenero
        public IEnumerable<TipoGenero> GetGeneros()
        {
            IEnumerable<TipoGenero> lista = null;
            try
            {
                IServiceTipoGenero _SeviceTipoGenero = new ServiceTipoGenero();
                lista = _SeviceTipoGenero.GetTipoGeneros();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return lista;
        }
    }
}