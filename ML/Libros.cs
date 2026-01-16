using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libros
    {
        public int IdLibros {  get; set; }
        public string Nombre {  get; set; }
        public int AÑoPublicado { get; set; }  
        public DateTime FechaDePublicacion { get; set; }
        public ML.Autor Autor { get; set; }
        public ML.Editorial Editorial { get; set; }

    }
}
