using RetoTecnico.DTOs;
using RetoTecnico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoTecnico.Interfaces
{
    public interface IAutorService
    {
        int RegistrarAutor(AutorCreateDto dto);
        List<Autor> ListarAutores();
    }
}
