using Infraestructure.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryProveedor : IRepositoryProveedor
    {


        public Proveedor GetProveedorByID(int id)
        {
            Proveedor oProveedor = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //oAgente = ctx.Agente.Find(id);
                oProveedor = ctx.Proveedor.Where(x => x.Id == id).Include("Calzado").
                    Include("Calzado.TipoGenero").
                    Include("Calzado.Tallas").
                    Include("Calzado.TipoMarca").
                    Include("Agente").FirstOrDefault();
                
            }
            return oProveedor;
        }

        public IEnumerable<Proveedor> GetProveedores()
        {
            try
            {
                IEnumerable<Proveedor> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.Proveedor.ToList<Proveedor>();
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
        public Proveedor Save(Proveedor proveedor)
        {
            int retorno = 0;
            Proveedor oproveedor = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oproveedor = GetProveedorByID((int)proveedor.Id);
                //IRepositoryAgente _RepositoryAgente = new RepositoryAgente();

                if (oproveedor == null)
                {

                    //Insertar
                    //if (agentes != null)
                    //{

                    //    proveedor.Agente = new List<Agente>();
                    //    foreach (var agente in agentes)
                    //    {
                    //        var agenteToAdd = _RepositoryAgente.GetAgenteByID(agente.Id);
                    //        ctx.Agente.Attach(agenteToAdd); //sin esto, EF intentará crear una categoría
                    //        proveedor.Agente.Add(agenteToAdd);// asociar a la categoría existente con el libro
                    //    }
                    //}
                    ctx.Proveedor.Add(proveedor);
                    //SaveChanges
                    //guarda todos los cambios realizados en el contexto de la base de datos.
                    retorno = ctx.SaveChanges();
                    //retorna número de filas afectadas
                }
                else
                {
                    //Registradas: 1,2,3
                    //Actualizar: 1,3,4

                    //Actualizar Libro
                    ctx.Proveedor.Add(proveedor);
                    ctx.Entry(proveedor).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                    //Actualizar Categorias
                    //var selectedCategoriasID = new HashSet<string>(selectedCategorias);
                    //if (selectedCategorias != null)
                    //{
                    //    ctx.Entry(libro).Collection(p => p.Categoria).Load();
                    //    var newCategoriaForLibro = ctx.Categoria
                    //     .Where(x => selectedCategoriasID.Contains(x.IdCategoria.ToString())).ToList();
                    //    libro.Categoria = newCategoriaForLibro;

                    //    ctx.Entry(libro).State = EntityState.Modified;
                    //    retorno = ctx.SaveChanges();
                    //}
                }
            }

            if (retorno >= 0)
                oproveedor = GetProveedorByID(proveedor.Id);

            return oproveedor;
        }
    }
}
