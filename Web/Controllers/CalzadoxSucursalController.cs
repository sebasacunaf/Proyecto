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
    public class CalzadoxSucursalController : Controller
    {
        // GET: CalzadoxSucursal
        public ActionResult GetCalzadoxSucursal()
        {
            IEnumerable<CalzadoxSucursal> lista = null;
            try
            {
                IServiceCalzadoxSucursal _SeviceCxS = new ServiceCalzadoxSucursal();
                lista = _SeviceCxS.GetCalzadoxSucursalBySucursal("Atenas");
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