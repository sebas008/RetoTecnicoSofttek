using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoTecnico.Entidades
{
    public class Autor
    {
        public int AutorId { get; set; }

        public string NombreCompleto { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string CiudadProcedencia { get; set; }

        public string CorreoElectronico { get; set; }

    }
}