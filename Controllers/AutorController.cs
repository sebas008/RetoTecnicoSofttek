using System.Web.Mvc;
using RetoTecnico.DTOs;
using RetoTecnico.Excepciones;
using RetoTecnico.Interfaces;

namespace RetoTecnico.Controllers
{
    public class AutoresController : Controller
    {
        private readonly IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var autores = _autorService.ListarAutores();
            return View(autores);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View(new AutorCreateDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(AutorCreateDto dto)
        {
            try
            {
                _autorService.RegistrarAutor(dto);
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
