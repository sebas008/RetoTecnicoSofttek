using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoTecnico.Excepciones
{
    public class AutorNoRegistradoException : ExcepcionesTotales
    {
        public AutorNoRegistradoException()
            : base("El autor no está registrado")
        {
        }
    }
}