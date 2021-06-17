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
    public class RepositoryTipoUsuario : IRepositoryTipoUsuario
    {
        public TipoUsuario GetTipoUsuarioByID(int id)
        {
            TipoUsuario oTipoUsuario= null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //oAgente = ctx.Agente.Find(id);
                oTipoUsuario = ctx.TipoUsuario.Where(x => x.Id == id).First<TipoUsuario>();
            }
            return oTipoUsuario;
        }

        public IEnumerable<TipoUsuario> GetTipoUsuarios()
        {
            try
            {

                IEnumerable<TipoUsuario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.TipoUsuario.ToList<TipoUsuario>();
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
