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
    public class AgenteController : Controller
    {
        // GET: Agente
        public ActionResult GetAgentes()
        {
           IEnumerable<Agente> lista = null;
            try
            {
                IServiceAgente _SeviceAgente = new ServiceAgente();
                lista = _SeviceAgente.GetAgentes();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetAgentesByProveedor()
        {
            IEnumerable<Agente> lista = null;
            try
            {
                IServiceAgente _SeviceAgente = new ServiceAgente();
                lista = _SeviceAgente.GetAgentesByProveedor(100);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetAgentesByID(int? id)
        {
            Agente agente = null;
            try
            {
                IServiceAgente _SeviceAgente = new ServiceAgente();
                agente = _SeviceAgente.GetAgenteByID(id.Value);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(agente);
        }
    }
}