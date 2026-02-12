using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoTecnico.Excepciones
{
    public class ExcepcionesTotales : Exception
    {
        public ExcepcionesTotales(string mensaje)
            : base(mensaje)
        {
        }
    }
}