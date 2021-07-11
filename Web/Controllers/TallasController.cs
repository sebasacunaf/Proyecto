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
    public class TallasController : Controller
    {
        // GET: Tallas
        public IEnumerable<Tallas> GetTallasByDescripcion()
        {
            IEnumerable<Tallas> lista = null;
            try
            {
                IServiceTallas _SeviceTallas = new ServiceTallas();
                lista = _SeviceTallas.GetTallas();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return lista;
        }
        public Tallas GetTallaByID(int ? id)
        {
            Tallas talla = null;
            try
            {
                IServiceTallas _SeviceTallas = new ServiceTallas();
                talla = _SeviceTallas.GetTallasByID(35);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return talla;
        }
    }
}