using RetoTecnico.Data;
using RetoTecnico.DTOs;
using RetoTecnico.Entidades;
using RetoTecnico.Excepciones;
using RetoTecnico.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace RetoTecnico.Servicios
{
    public class AutorService : IAutorService
    {
        private readonly BibliotecaContext _db;

        public AutorService(BibliotecaContext db)
        {
            _db = db;
        }

        public int RegistrarAutor(AutorCreateDto dto)
        {
            if (dto == null)
                throw new ExcepcionesTotales("Solicitud inválida.");

            // Obligatorios (*)
            if (string.IsNullOrWhiteSpace(dto.NombreCompleto))
                throw new ExcepcionesTotales("Nombre completo es obligatorio.");

            if (dto.FechaNacimiento == default(DateTime))
                throw new ExcepcionesTotales("Fecha de nacimiento es obligatoria.");

            if (string.IsNullOrWhiteSpace(dto.CorreoElectronico))
                throw new ExcepcionesTotales("Correo electrónico es obligatorio.");

            var autor = new Autor
            {
                NombreCompleto = dto.NombreCompleto.Trim(),
                FechaNacimiento = dto.FechaNacimiento.Date,
                CiudadProcedencia = string.IsNullOrWhiteSpace(dto.CiudadProcedencia)
                    ? null
                    : dto.CiudadProcedencia.Trim(),
                CorreoElectronico = dto.CorreoElectronico.Trim()
            };

            _db.Autores.Add(autor);

            try
            {
                _db.SaveChanges();
                return autor.AutorId;
            }
            catch (DbUpdateException)
            {
                throw new ExcepcionesTotales("Ya existe un autor registrado con ese correo electrónico.");
            }
        }

        public List<Autor> ListarAutores()
        {
            return _db.Autores
                      .OrderBy(a => a.NombreCompleto)
                      .ToList();
        }
    }
}