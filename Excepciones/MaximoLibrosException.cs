using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoTecnico.Excepciones
{
    public class MaximoLibrosException : ExcepcionesTotales
    {
        public MaximoLibrosException()
            : base("No es posible registrar el libro, se alcanzó el máximo permitido.")
        {
        }
    }
}