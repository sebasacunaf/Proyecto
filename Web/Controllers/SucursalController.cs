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
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult GetSucursales()
        {
            IEnumerable<Sucursal> lista = null;
            try
            {
                IServiceSucursal _SeviceSucursal = new ServiceSucursal();
                lista = _SeviceSucursal.GetSucursals();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetSucursalesByCalzado(int? id)
        {
            IEnumerable<Sucursal> lista = null;
            try
            {
                IServiceSucursal _SeviceSucursal = new ServiceSucursal();
                lista = _SeviceSucursal.GetSucursals();
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