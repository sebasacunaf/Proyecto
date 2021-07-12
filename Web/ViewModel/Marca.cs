using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class Marca
    {
        public string Nombre { get; set; }
        public Marca(string nombre)
        {
            this.Nombre = nombre;
        }
    }
}