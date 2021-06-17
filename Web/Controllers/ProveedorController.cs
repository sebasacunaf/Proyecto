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
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult GetProveedores()
        {
            IEnumerable<Proveedor> lista = null;
            try
            {
                IServiceProveedor _SeviceP = new ServiceProveedor();
                lista = _SeviceP.GetProveedores();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetProveedorByID(int? id)
        {
            Proveedor pro = null;
            try
            {
               IServiceProveedor _SeviceP = new ServiceProveedor();
               pro = _SeviceP.GetProveedorByID(id.Value);

               IServiceAgente _SeviceA = new ServiceAgente();
               pro.Agente = (ICollection<Agente>)_SeviceA.GetAgentesByProveedor(pro.Id);

               //pro.Calzado = (ICollection<Calzado>) 
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(pro);
        }
    }
}