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
    public class TipoMovimientoController : Controller
    {
        // GET: TipoMovimiento
        public IEnumerable<TipoMovimiento> GetGestion()
        {
            IEnumerable<TipoMovimiento> lista = null;
            try
            {
                IServiceTipoMovimiento _SeviceTM = new ServiceTipoMovimiento();
                lista = _SeviceTM.GetTipoMovimientos();
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