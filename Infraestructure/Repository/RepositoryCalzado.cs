using Infraestructure.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryCalzado : IRepositoryCalzado
    {
        public Calzado GetCalzadoByID(int id)
        {
            Calzado oCalzado = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oCalzado = ctx.Calzado.Where(l => l.Id == id).Include("TipoGenero").
                    Include("Tallas").Include("TipoMarca").Include("Proveedor")
                    .Include("CalzadoxSucursal").Include("CalzadoxSucursal.Sucursal").FirstOrDefault();
            }
            return oCalzado;
        }

        public IEnumerable<Calzado> GetCalzados()
        {
            try
            {

                IEnumerable<Calzado> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.Calzado.ToList<Calzado>();
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

        public IEnumerable<Calzado> GetCalzadosByGenero(string genero)
        {
            try
            {

                IEnumerable<Calzado> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.Calzado.Where(x => x.IdGenero == genero).ToList<Calzado>();
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

        public IEnumerable<Calzado> GetCalzadosByMarca(string marca)
        {
            try
            {

                IEnumerable<Calzado> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.Calzado.Where(x => x.NombreMarca == marca).ToList<Calzado>();
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

        public IEnumerable<Calzado> GetCalzadosByTalla(int talla)
        {
            try
            {

                IEnumerable<Calzado> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.Calzado.Where(x => x.IdTalla == talla).ToList<Calzado>();
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
        public Calzado Save(Calzado calzado, string[] calzadoxSucursales, string[] proveedores)
        {
            int retorno = 0;
            Calzado ocalzado = null;
            using (MyContext ctx = new MyContext())
            {
                using (var transaccion = ctx.Database.BeginTransaction())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ocalzado = GetCalzadoByID((int)calzado.Id);
                    IRepositoryProveedor repoPro = new RepositoryProveedor();
                    if (ocalzado == null)
                    {
                        if (calzadoxSucursales != null)
                        {

                            calzado.CalzadoxSucursal = new List<CalzadoxSucursal>();

                            foreach (var calzadoxSucursal in calzadoxSucursales)
                            {
                                CalzadoxSucursal CxSToAdd = new CalzadoxSucursal();
                                CxSToAdd.Cantidad = 0;
                                CxSToAdd.IdCalzado = calzado.Id;
                                CxSToAdd.IdSucursal = calzadoxSucursal;
                                ctx.CalzadoxSucursal.Attach(CxSToAdd); //sin esto, EF intentará crear una categoría
                                calzado.CalzadoxSucursal.Add(CxSToAdd); // asociar a la categoría existente con el libro
                                retorno = ctx.SaveChanges();
                            }
                        }
                        if (proveedores != null)
                        {
                            calzado.Proveedor = new List<Proveedor>();
                            foreach (var proveedor in proveedores)
                            {
                                Proveedor ProToAdd = repoPro.GetProveedorByID(int.Parse(proveedor));
                                ctx.Proveedor.Attach(ProToAdd); //sin esto, EF intentará crear una categoría
                                calzado.Proveedor.Add(ProToAdd); // asociar a la categoría existente con el libro
                                retorno = ctx.SaveChanges();
                            }
                        }
                        ctx.Calzado.Add(calzado);
                        retorno = ctx.SaveChanges();
                        transaccion.Commit();

                    }

                    else
                    {
                        //Actualizar Libro
                        ctx.Calzado.Add(calzado);
                        ctx.Entry(calzado).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                        //Actualizar CalzadoxSucursal
                        var selectedCalzadoxSucursalesID = new HashSet<string>(calzadoxSucursales);
                        if (calzadoxSucursales != null)
                        {
                            ctx.Entry(calzado).Collection(p => p.CalzadoxSucursal).Load();
                            var newCxSForCalzado = ctx.CalzadoxSucursal.Where(x => selectedCalzadoxSucursalesID.Contains(x.IdSucursal)).ToList();
                            calzado.CalzadoxSucursal = newCxSForCalzado;

                            ctx.Entry(calzado).State = EntityState.Modified;
                            retorno = ctx.SaveChanges();
                        }
                        var selectedProveedoresID = new HashSet<string>(proveedores);
                        if (proveedores != null)
                        {
                            ctx.Entry(calzado).Collection(p => p.Proveedor).Load();
                            var newProForCalzado = ctx.Proveedor.Where(x => selectedProveedoresID.Contains(x.Id.ToString())).ToList();
                            calzado.Proveedor = newProForCalzado;

                            ctx.Entry(calzado).State = EntityState.Modified;
                            retorno = ctx.SaveChanges();
                        }
                    }
                }

                if (retorno >= 0)
                    ocalzado = GetCalzadoByID(calzado.Id);

                return ocalzado;
            }
        }
    }
}
