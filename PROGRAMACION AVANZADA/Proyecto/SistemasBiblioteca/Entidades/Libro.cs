using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasBiblioteca.Entidades
{
    public class Libro
    {
        public int IdLibro { get; set; }

        public string Codigo { get; set; }

        public string ISBN { get; set; }

        public string Titulo { get; set; }

        public int Stock { get; set; }

        public int IdAutor { get; set; }

        public int IdEditorial { get; set; }
    }
}