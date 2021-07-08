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
        public Calzado Save(Calzado calzado, TipoGenero tipoGenero, Tallas tallas, TipoMarca tipoMarca, CalzadoxSucursal[] calzadoxSucursals, Proveedor[] proveedores)
        {
            int retorno = 0;
            Calzado ocalzado = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                ocalzado = GetCalzadoByID((int)calzado.Id);
                IRepositoryTipoGenero _RepositoryTipoGenero = new RepositoryTipoGenero();
                IRepositoryTallas _RepositoryTallas = new RepositoryTallas();
                IRepositoryTipoMarca _RepositoryTipoMarca = new RepositoryTipoMarca();
                IRepositoryCalzadoxSucursal _RepositoryCalzadoxSucursal = new RepositoryCalzadoxSucursal();
                IRepositorySucursal _RepositorySucursal = new RepositorySucursal();
                IRepositoryProveedor _RepositoryProveedor = new RepositoryProveedor();
                if (ocalzado == null)
                {
                    //Insertar
                    if (tipoGenero != null)
                    {
                        calzado.TipoGenero = new TipoGenero();
                        //foreach (var agente in agentes)
                        //{
                        var tipoGeneroToAdd = _RepositoryTipoGenero.GetTipoGeneroByID(tipoGenero.Id);
                        ctx.TipoGenero.Attach(tipoGeneroToAdd); //sin esto, EF intentará crear una categoría
                        calzado.TipoGenero = tipoGeneroToAdd; // asociar a la categoría existente con el libro
                        //}
                    }
                    if (tallas != null)
                    {
                        calzado.Tallas = new Tallas();
                        //foreach (var agente in agentes)
                        //{
                        var tallasToAdd = _RepositoryTallas.GetTallasByID((int)tallas.Id);
                        ctx.Tallas.Attach(tallasToAdd); //sin esto, EF intentará crear una categoría
                        calzado.Tallas = tallasToAdd; // asociar a la categoría existente con el libro
                        //}
                    }
                    if (tipoMarca != null)
                    {
                        calzado.TipoMarca = new TipoMarca();
                        //foreach (var agente in agentes)
                        //{
                        var tipoMarcaToAdd = _RepositoryTipoMarca.GetTipoMarcaByID(tipoMarca.Nombre);
                        ctx.TipoMarca.Attach(tipoMarcaToAdd); //sin esto, EF intentará crear una categoría
                        calzado.TipoMarca = tipoMarcaToAdd; // asociar a la categoría existente con el libro
                        //}
                    }
                    if (calzadoxSucursals != null)
                    {
                        calzado.CalzadoxSucursal = new List<CalzadoxSucursal>();
                        foreach (var calzadoxSucursal in calzadoxSucursals)
                        {
                            CalzadoxSucursal calzadoxSucursalToAdd = new CalzadoxSucursal();
                            var sucursal = _RepositorySucursal.GetSucursalByID(calzadoxSucursal.IdSucursal);
                            calzadoxSucursalToAdd.IdSucursal = sucursal.Id;
                            calzadoxSucursalToAdd.Sucursal = sucursal;
                            calzadoxSucursalToAdd.IdCalzado = calzado.Id;
                            calzadoxSucursalToAdd.Calzado = calzado;
                            calzadoxSucursalToAdd.Cantidad = calzadoxSucursal.Cantidad;
                            ctx.CalzadoxSucursal.Attach(calzadoxSucursalToAdd); //sin esto, EF intentará crear una categoría
                            calzado.CalzadoxSucursal.Add(calzadoxSucursalToAdd); // asociar a la categoría existente con el libro
                        }
                    }
                    if (proveedores != null)
                    {
                        calzado.Proveedor = new List<Proveedor>();
                        foreach (var proveedor in proveedores)
                        {
                            Proveedor proveedorToAdd = new Proveedor();
                            proveedorToAdd = _RepositoryProveedor.GetProveedorByID(proveedor.Id);
                            ctx.Proveedor.Attach(proveedorToAdd); //sin esto, EF intentará crear una categoría
                            calzado.Proveedor.Add(proveedorToAdd); // asociar a la categoría existente con el libro
                        }
                    }
                    ctx.Calzado.Add(calzado);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    //Actualizar Libro
                    ctx.Calzado.Add(calzado);
                    ctx.Entry(calzado).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                    //Actualizar Proveedores
                    var selectedProveedoresID = new HashSet<Proveedor>(proveedores);
                    if (proveedores != null)
                    {
                        ctx.Entry(calzado).Collection(p => p.Proveedor).Load();
                        var newProveedorForCalzado = ctx.Proveedor.Where(x => selectedProveedoresID.Contains(x)).ToList();
                        calzado.Proveedor = newProveedorForCalzado;

                        ctx.Entry(calzado).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }


                    var selectedCalzadoxSucursalsID = new HashSet<CalzadoxSucursal>(calzadoxSucursals);
                    if (calzadoxSucursals != null)
                    {
                        ctx.Entry(calzado).Collection(p => p.CalzadoxSucursal).Load();
                        var newCxSForCalzado = ctx.CalzadoxSucursal.Where(x => selectedCalzadoxSucursalsID.Contains(x)).ToList();
                        calzado.CalzadoxSucursal = newCxSForCalzado;

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
