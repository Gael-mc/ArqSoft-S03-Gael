using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers
{
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
        private readonly ItemService _service;

        public CatalogoController(ItemService service)
        {
            _service = service;
        }

        // GET /Catalogo?genero=xxx
        [HttpGet("")]
        public IActionResult Index(string? genero)
        {
            var items = string.IsNullOrEmpty(genero)
                ? _service.ObtenerTodos()
                : _service.ObtenerPorGenero(genero);

            ViewBag.Generos = _service.ObtenerGeneros();
            ViewBag.GeneroActual = genero;

            return View(items);
        }

        // GET /Catalogo/Detalle/5
        [HttpGet("Detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var item = _service.ObtenerPorId(id);
            return item == null ? NotFound() : View(item);
        }

        // GET /Catalogo/Agregar
        [HttpGet("Agregar")]
        public IActionResult Agregar()
        {
            return View();
        }

        // POST /Catalogo/Agregar
        [HttpPost("Agregar")]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Item item)
        {
            if (!ModelState.IsValid)          // ← validación del modelo
                return View(item);

            _service.Agregar(item);
            return RedirectToAction(nameof(Index));
        }

        // POST /Catalogo/Eliminar/5  ← debe ser POST, no GET
        [HttpPost("Eliminar/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            _service.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}