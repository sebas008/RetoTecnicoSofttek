using RetoTecnico.DTOs;
using RetoTecnico.Excepciones;
using RetoTecnico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetoTecnico.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        // ===== LISTAR =====
        [HttpGet]
        public ActionResult Index()
        {
            var libros = _libroService.ListarLibros();
            return View(libros);
        }

        // ===== CREAR (GET) =====
        [HttpGet]
        public ActionResult Crear()
        {
            return View(new LibroCreateDto());
        }

        // ===== CREAR (POST) =====
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(LibroCreateDto dto)
        {
            try
            {
                var id = _libroService.RegistrarLibro(dto);
                TempData["OK"] = "Libro registrado. ID: " + id;
                return RedirectToAction("Index");
            }
            catch (ExcepcionesTotales ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dto);
            }
        }
    }
}