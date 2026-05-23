using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentacion.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ItemService _service;
        public CatalogoController(ItemService service) => _service = service;

        // ── INDEX ────────────────────────────────────────
        public IActionResult Index(string? genero)
        {
            var items = string.IsNullOrEmpty(genero)
                ? _service.GetAll()
                : _service.GetByGenero(genero);

            ViewBag.Generos = _service.GetGeneros();
            ViewBag.GeneroActivo = genero;
            return View(items);
        }

        // ── DETALLE ──────────────────────────────────────
        public IActionResult Detalle(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // ── AGREGAR RESEÑA ───────────────────────────────
        [HttpPost]
        public IActionResult AgregarResena(int id, string texto, int estrellas, string autor)
        {
            _service.AgregarResena(id, new Resena
            {
                Texto = texto,
                Estrellas = Math.Clamp(estrellas, 1, 5),
                Autor = string.IsNullOrWhiteSpace(autor) ? "Anónimo" : autor
            });
            return RedirectToAction("Detalle", new { id });
        }

        // ── AGREGAR JUEGO ────────────────────────────────
        public IActionResult Agregar() => View(new Item());

        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            if (!ModelState.IsValid) return View(item);
            _service.Add(item);
            return RedirectToAction("Index");
        }

        // ── ELIMINAR ─────────────────────────────────────
        public IActionResult Eliminar(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}