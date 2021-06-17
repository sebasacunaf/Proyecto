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
    public class DetalleGestionController : Controller
    {
        // GET: DetalleGestion
        public ActionResult GetDetalleGestionByID(int? id)
        {
            IEnumerable<GestionDetalle> lista = null;
            try
            {
                IServiceGestionDetalle _SeviceGS = new ServiceGestionDetalle();
                lista = _SeviceGS.GetGestionDetallesByIDGestion(id.Value);
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