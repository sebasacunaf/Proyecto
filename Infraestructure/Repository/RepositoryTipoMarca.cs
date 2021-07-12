using Infraestructure.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryTipoMarca : IRepositoryTipoMarca
    {
        public TipoMarca GetTipoMarcaByID(string nombre)
        {
            TipoMarca oTipoMarca = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oTipoMarca = ctx.TipoMarca.Where(l => l.Nombre == nombre).FirstOrDefault();
            }
            return oTipoMarca;
        }

        public IEnumerable<TipoMarca> GetTipoMarcas()
        {
            try
            {
                IEnumerable<TipoMarca> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.TipoMarca.ToList<TipoMarca>();
                }
                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
}
