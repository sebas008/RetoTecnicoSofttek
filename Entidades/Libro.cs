using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoTecnico.Entidades
{
    public class Libro
    {
        public int LibroId { get; set; }

        public string Titulo { get; set; }

        public int Anio { get; set; }

        public string Genero { get; set; }

        public int? NumeroPaginas { get; set; }

        public int AutorId { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}