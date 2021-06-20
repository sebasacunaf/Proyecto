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
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult GetGestion()
        {
            IEnumerable<Gestion> lista = null;
            try
            {
                IServiceGestion _SeviceCalzado = new ServiceGestion();
                lista = _SeviceCalzado.GetGestions();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }

        public ActionResult GetGestionByEntrada()
        {
            IEnumerable<Gestion> lista = null;
            try
            {
                IServiceGestion _SeviceCalzado = new ServiceGestion();
                lista = _SeviceCalzado.GetGestionsByEntrada();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetGestionBySalida()
        {
            IEnumerable<Gestion> lista = null;
            try
            {
                IServiceGestion _SeviceCalzado = new ServiceGestion();
                lista = _SeviceCalzado.GetGestionsBySalida();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetGestionByFecha(string fecha)
        {
            IEnumerable<Gestion> lista = null;
            try
            {
                IServiceGestion _SeviceCalzado = new ServiceGestion();
                lista = _SeviceCalzado.GetGestionsByFecha(Convert.ToString(DateTime.Today.Date));
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
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