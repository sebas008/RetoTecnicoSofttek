using RetoTecnico.Data;
using RetoTecnico.DTOs;
using RetoTecnico.Entidades;
using RetoTecnico.Excepciones;
using RetoTecnico.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RetoTecnico.Servicios
{
    public class LibroService : ILibroService
    {
        private readonly BibliotecaContext _db;
        private readonly int _maxLibros;

        public LibroService(BibliotecaContext db)
        {
            _db = db;
            _maxLibros = int.Parse(ConfigurationManager.AppSettings["MaxLibrosPermitidos"] ?? "100");
        }

        public int RegistrarLibro(LibroCreateDto dto)
        {
            // Obligatorios (*)
            if (dto == null) throw new ExcepcionesTotales("Solicitud inválida.");
            if (string.IsNullOrWhiteSpace(dto.Titulo)) throw new ExcepcionesTotales("Título es obligatorio.");
            if (dto.Anio <= 0) throw new ExcepcionesTotales("Año es obligatorio.");
            if (dto.AutorId <= 0) throw new ExcepcionesTotales("Autor es obligatorio.");

            // Regla: máximo de libros
            var totalLibros = _db.Libros.Count();
            if (totalLibros >= _maxLibros)
                throw new MaximoLibrosException(); // mensaje exacto

            // Regla: autor debe existir
            var autorExiste = _db.Autores.Any(a => a.AutorId == dto.AutorId);
            if (!autorExiste)
                throw new AutorNoRegistradoException(); // mensaje exacto

            var libro = new Libro
            {
                Titulo = dto.Titulo.Trim(),
                Anio = dto.Anio,
                Genero = string.IsNullOrWhiteSpace(dto.Genero) ? null : dto.Genero.Trim(),
                NumeroPaginas = dto.NumeroPaginas,
                AutorId = dto.AutorId,
                FechaRegistro = DateTime.Now   // 👈 ESTA ES LA LÍNEA CLAVE
            };


            _db.Libros.Add(libro);
            _db.SaveChanges();

            return libro.LibroId;
        }

        public List<Libro> ListarLibros()
        {
            return _db.Libros
                      .OrderBy(l => l.Titulo)
                      .ToList();
        }
    }
}