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
    public class TipoMarcaController : Controller
    {
        // GET: TipoMarca
        public IEnumerable<TipoMarca> GetMarcas()
        {
            IEnumerable<TipoMarca> lista = null;
            try
            {
                IServiceTipoMarca _SeviceTipoMarca = new ServiceTipoMarca();
                lista = _SeviceTipoMarca.GetTipoMarcas();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return lista;
        }
    }
}