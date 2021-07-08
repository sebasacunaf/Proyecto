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
    public class RepositorySucursal : IRepositorySucursal
    {
        public Sucursal GetSucursalByID(string id)
        {
                Sucursal oSucursal = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //oAgente = ctx.Agente.Find(id);
                    oSucursal = ctx.Sucursal.Where(x => x.Id == id).FirstOrDefault();
                }
                return oSucursal;
        }

        public IEnumerable<Sucursal> GetSucursals()
        {
            try
            {

                IEnumerable<Sucursal> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.Sucursal.ToList<Sucursal>();
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
