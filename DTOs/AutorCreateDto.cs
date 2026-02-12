using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoTecnico.DTOs
{
    public class AutorCreateDto
    {

        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string CorreoElectronico { get; set; }

    }
}