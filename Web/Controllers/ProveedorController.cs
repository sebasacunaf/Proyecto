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
        public ActionResult buscarProveedorxNombre(string filtro)
        {
            IEnumerable<Proveedor> lista = null;
            IServiceProveedor _ServicePro = new ServiceProveedor();

            // Error porque viene en blanco 
            if (string.IsNullOrEmpty(filtro))
            {
                lista = _ServicePro.GetProveedores();
            }
            else
            {
                lista = _ServicePro.GetProveedorByNombre(filtro);
            }


            // Retorna un Partial View
            return PartialView("_PartialViewProveedores", lista);
        }
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

        public ActionResult CreateProveedor()
        {
            //Lista de autores
            return View();
        }
        public ActionResult Editar(int? id)
        {
            ServiceProveedor _ServiceProveedor = new ServiceProveedor();
            Proveedor proveedor = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                proveedor = _ServiceProveedor.GetProveedorByID(id.Value);
                if (proveedor == null)
                {
                    TempData["Message"] = "No existe el proveedor solicitado";
                    TempData["Redirect"] = "Proveedor";
                    TempData["Redirect-Action"] = "GetProveedores";
                    //Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //Lista de autores
                //ViewBag.Proveedores = listaProveedores(agente.IdProveedor.Value);
                return View(proveedor);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Proveedor";
                TempData["Redirect-Action"] = "GetProveedores";
                //Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Save(Proveedor proveedor)
        {
            IServiceProveedor _ServiceProveedor = new ServiceProveedor();
            try
            {
                if (ModelState.IsValid)
                {
                    Proveedor oProveedor = _ServiceProveedor.Save(proveedor);
                }
                else
                {
                    Util.Util.ValidateErrors(this);
                    return View("CreateProveedor", proveedor);
                }

                return RedirectToAction("GetProveedores");
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
    }
}