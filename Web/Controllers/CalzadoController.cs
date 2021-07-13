using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class CalzadoController : Controller
    {

        public ActionResult Editar(int? id)
        {
            ServiceCalzado _ServiceCalzado = new ServiceCalzado();
            Calzado calzado = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                calzado = _ServiceCalzado.GetCalzadoByID(id.Value);
                if (calzado == null)
                {
                    TempData["Message"] = "No existe el calzado solicitado";
                    TempData["Redirect"] = "Calzado";
                    TempData["Redirect-Action"] = "GetCalzados";
                    //Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //Lista de autores
            ViewBag.Marca = listaMarcas(calzado.NombreMarca);
            ViewBag.TipoGenero = listaGenero();
            ViewBag.Proveedores = listaProveedores();
            ViewBag.Tallas = listaTallas();
            ViewBag.Sucursal = listaSucursales(null);
                return View(calzado);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Calzado";
                TempData["Redirect-Action"] = "GetCalzados";
                //Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
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
        private SelectList listaTallas()
        {
            //Lista de autores
            IServiceTallas _ServiceTallas = new ServiceTallas();
            IEnumerable<Tallas> listaTallas = _ServiceTallas.GetTallas();
            //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaTallas, "Id", "Talla");
        }
        private SelectList listaGenero()
        {
            //Lista de autores
            IServiceTipoGenero _ServiceTipoGenero = new ServiceTipoGenero();
            IEnumerable<TipoGenero> listaGenero = _ServiceTipoGenero.GetTipoGeneros();
            //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaGenero, "Id", "Id");
        }
        //private SelectList listaCategoria()
        //{
        //    //Lista de autores
        //    List<Clasificacion> listaCategoria = new List<Clasificacion>();
        //    listaCategoria.Add(new Clasificacion(1, "Niño"));
        //    listaCategoria.Add(new Clasificacion(2, "Adulto"));
        //    //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
        //    return new SelectList(listaCategoria, "Id", "Categoria");
        //}
        private SelectList listaMarcas(string Nombre ="")
        {
            //Lista de autores
            IServiceTipoMarca _ServiceTipoMarca = new ServiceTipoMarca();
            IEnumerable<TipoMarca> listaMarca = _ServiceTipoMarca.GetTipoMarcas();
            //SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaMarca, "Nombre", "Nombre", Nombre);
        }
        private MultiSelectList listaSucursales(ICollection<Sucursal> sucursales)
        {
            //Lista de Categorias
            IServiceSucursal _ServiceSucursal = new ServiceSucursal();
            IEnumerable<Sucursal> listaSucursales = _ServiceSucursal.GetSucursals();
            string[] listaSucursalesSelect = null;
            if (sucursales != null)
            {

                listaSucursalesSelect = sucursales.Select(c => c.Id.ToString()).ToArray();
            }
            return new MultiSelectList(listaSucursales, "Id", "Id", listaSucursalesSelect);
        }
        private SelectList listaProveedores()
        {
            //Lista de autores
            IServiceProveedor _ServiceProveedor = new ServiceProveedor();
            IEnumerable<Proveedor> listaProveedor = _ServiceProveedor.GetProveedores();
            //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaProveedor, "Id", "Nombre");
        }
        public ActionResult CreateCalzado()
        {
            //Lista de autores
            ViewBag.Marca = listaMarcas();
            ViewBag.TipoGenero = listaGenero();
            ViewBag.Proveedores = listaProveedores();
            ViewBag.Tallas = listaTallas();
            ViewBag.Sucursal = listaSucursales(null);
            return View();
        }
        [HttpPost]
        public ActionResult Save(Calzado calzado, string[] calzadoxSucursales,string[] proveedores )
        {
            IServiceCalzado _ServiceCalzado = new ServiceCalzado();
            try
            {
                if (ModelState.IsValid)
                {
                    Calzado oCalzado = _ServiceCalzado.Save(calzado, calzadoxSucursales, proveedores);
                }
                else
                {
                    Util.Util.ValidateErrors(this);
                    ViewBag.Marca = listaMarcas();
                    ViewBag.TipoGenero = listaGenero();
                    ViewBag.Proveedores = listaProveedores();
                    ViewBag.Tallas = listaTallas();
                    ViewBag.Sucursal = listaSucursales(null);
                    return View("CreateCalzado", calzado);
                }

                return RedirectToAction("GetCalzados");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Calzado";
                TempData["Redirect-Action"] = "GetCalzados";
                // Redireccion a la captura del Error
                return RedirectToAction("");
            }
        }
    }
}