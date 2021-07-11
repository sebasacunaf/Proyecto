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
        private SelectList listaProveedores()
        {
            //Lista de autores
            IServiceProveedor _ServiceProveedor = new ServiceProveedor();
            IEnumerable<Proveedor> listaProveedor = _ServiceProveedor.GetProveedores();
            //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaProveedor, "Id", "Nombre");
        }
        public ActionResult CreateAgente()
        {
            //Lista de autores
            ViewBag.Proveedores = listaProveedores();
            return View();
        }
        [HttpPost]
        public ActionResult Editar(int? id)
        {
            ServiceAgente _ServiceAgente = new ServiceAgente();
            Agente agente = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                agente = _ServiceAgente.GetAgenteByID(id.Value);
                if (agente == null)
                {
                    TempData["Message"] = "No existe el agente solicitado";
                    TempData["Redirect"] = "Agente";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //Lista de autores
                ViewBag.Proveedores = listaProveedores();
                return View(agente);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Agente";
                TempData["Redirect-Action"] = "GetProveedores";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        [HttpPost]
        public ActionResult Save(Agente agente)
        {
            IServiceAgente _ServiceAgente = new ServiceAgente();
            try
            {
                if (ModelState.IsValid)
                {
                    Agente oAgente = _ServiceAgente.Save(agente);
                }
                else
                {
                    Util.Util.ValidateErrors(this);
                    return View("CreateAgente", agente);
                }

                return RedirectToAction("GetProveedorByID", "Proveedor", new { id = agente.IdProveedor });
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Proveedor";
                TempData["Redirect-Action"] = "GetProveedores";
                // Redireccion a la captura del Error
                return RedirectToAction("");
            }
        }
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