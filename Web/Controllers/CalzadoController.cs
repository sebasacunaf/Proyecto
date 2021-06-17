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
    public class CalzadoController : Controller
    {
        // GET: Calzado
        public ActionResult GetCalzados()
        {
            IEnumerable<Calzado> lista = null;
            try
            {
                IServiceCalzado _SeviceCalzado = new ServiceCalzado();
                lista = _SeviceCalzado.GetCalzados();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetCalzadosByID(int? id)
        {
            Calzado calzado = null;
            try
            {
                IServiceCalzado _SeviceCalzado = new ServiceCalzado();
                calzado = _SeviceCalzado.GetCalzadoByID(id.Value);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(calzado);
        }
        public ActionResult GetCalzadosByGenero()
        {
            IEnumerable<Calzado> lista = null;
            try
            {
                IServiceCalzado _SeviceCalzado = new ServiceCalzado();
                lista = _SeviceCalzado.GetCalzadosByGenero("Femenino");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetCalzadosByMarca()
        {
            IEnumerable<Calzado> lista = null;
            try
            {
                IServiceCalzado _SeviceCalzado = new ServiceCalzado();
                lista = _SeviceCalzado.GetCalzadosByMarca("Puma");
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