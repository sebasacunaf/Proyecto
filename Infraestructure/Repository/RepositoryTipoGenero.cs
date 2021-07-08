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
    public class RepositoryTipoGenero : IRepositoryTipoGenero
    {
        public TipoGenero GetTipoGeneroByID(string id)
        {
            TipoGenero oTipoGenero = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oTipoGenero = ctx.TipoGenero.Where(l => l.Id == id).FirstOrDefault();
            }
            return oTipoGenero;
        }

        public IEnumerable<TipoGenero> GetTipoGeneros()
        {
            try
            {

                IEnumerable<TipoGenero> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.TipoGenero.ToList<TipoGenero>();
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
