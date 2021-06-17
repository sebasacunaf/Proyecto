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
    public class DetalleMovimientoController : Controller
    {
        // GET: DetalleMovimiento
        public ActionResult GetDetallesMovimiento()
        {
            IEnumerable<DetalleMovimiento> lista = null;
            try
            {
                IServiceDetalleMovimiento _SeviceDM = new ServiceDetalleMoviemiento();
                lista = _SeviceDM.GetDetalleMovimientosByTipo("Entrada");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
    }
}