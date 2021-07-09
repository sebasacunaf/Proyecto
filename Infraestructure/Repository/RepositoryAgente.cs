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
    public class RepositoryAgente : IRepositoryAgente
    {
        public Agente GetAgenteByID(int id)
        {
            Agente oAgente = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //oAgente = ctx.Agente.Find(id);
                oAgente = ctx.Agente.Where(x => x.Id == id).FirstOrDefault();
            }
            return oAgente;
        }
        public IEnumerable<Agente> GetAgentes()
        {
            try
            {

                IEnumerable<Agente> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.Agente.ToList<Agente>();
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

        public IEnumerable<Agente> GetAgentesByProveedor(int id)
        {
            try
            {

                IEnumerable<Agente> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Select * from Autor
                    lista = ctx.Agente.Where(x => x.IdProveedor == id).ToList<Agente>();
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
        public Agente Save(Agente agente)
        {
            int retorno = 0;
            Agente oAgente = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oAgente = GetAgenteByID(agente.Id);
                //IRepositoryAgente _RepositoryAgente = new RepositoryAgente();

                if (oAgente == null)
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
                    ctx.Agente.Add(agente);
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
                    ctx.Agente.Add(agente);
                    ctx.Entry(agente).State = EntityState.Modified;
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
                oAgente = GetAgenteByID(agente.Id);

            return oAgente;
        }
    }
}
