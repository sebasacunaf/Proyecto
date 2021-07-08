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
        private SelectList listaTallas(string descripcion="")
        {
            //Lista de autores
            IServiceTallas _ServiceTallas = new ServiceTallas();
            IEnumerable<Tallas> listaTallas = _ServiceTallas.GetTallas(descripcion);
            //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaTallas, "Id", "Talla", descripcion);
        }
        private SelectList listaGenero()
        {
            //Lista de autores
            IServiceTipoGenero _ServiceTipoGenero = new ServiceTipoGenero();
            IEnumerable<TipoGenero> listaGenero = _ServiceTipoGenero.GetTipoGeneros();
            //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaGenero, "Id", "Tipo Género");
        }
        private SelectList listaCategoria()
        {
            //Lista de autores
            List<string> listaCategoria = new List<string>();
            listaCategoria.Add("Adulto");
            listaCategoria.Add("Niño");
            //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaCategoria, "Id", "Categoría");
        }
        private SelectList listaMarcas()
        {
            //Lista de autores
            IServiceTipoMarca _ServiceTipoMarca = new ServiceTipoMarca();
            IEnumerable<TipoMarca> listaMarca = _ServiceTipoMarca.GetTipoMarcas();
            //Autor SelectAutor = listaAutores.Where(c => c.IdAutor == idAutor).FirstOrDefault();
            return new SelectList(listaMarca, "Nombre", "Marca");
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
            return new MultiSelectList(listaSucursales, "IdSucursales", "Nombre", listaSucursalesSelect);
        }
        public ActionResult CreateCalzado()
        {
            //Lista de autores
            ViewBag.Marca = listaMarcas();
            ViewBag.TipoGenero = listaGenero();
            ViewBag.Categoria = listaCategoria();
            ViewBag.Tallas = listaTallas();
            ViewBag.Sucursal = listaSucursales(null);
            return View();
        }
        public ActionResult Save(Calzado calzado)
        {
            IServiceCalzado _ServiceCalzado = new ServiceCalzado();
            try
            {
                if (ModelState.IsValid)
                {
                    Calzado oCalzado = _ServiceCalzado.Save(calzado);
                }
                else
                {
                    Util.Util.ValidateErrors(this);
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