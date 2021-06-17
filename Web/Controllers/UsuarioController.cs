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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetUsuarios()
        {
            IEnumerable<Usuario> lista = null;
            try
            {
                IServiceUsuario _SeviceUsuario= new ServiceUsuario();
                lista = _SeviceUsuario.GetUsuarios();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }
        public ActionResult GetUsuariobyIDVista(int? id)
        {
            Usuario usuario = null;
            try
            {
                IServiceUsuario _SeviceUsuario = new ServiceUsuario();
                usuario = _SeviceUsuario.GetUsuarioByID(208060513);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(usuario);
        }
        public Usuario GetUsuariobyID(int? id)
        {
            Usuario usuario = null;
            try
            {
                IServiceUsuario _SeviceUsuario = new ServiceUsuario();
                usuario = _SeviceUsuario.GetUsuarioByID(208060513);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return usuario;
        }
    }
}