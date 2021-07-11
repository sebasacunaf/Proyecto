using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class Clasificacion
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public Clasificacion(int id, string categoria)
        {
            this.Id = id;
            this.Categoria = categoria;
        }
    }
}