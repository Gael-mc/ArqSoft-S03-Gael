using CatalogoApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItemService _service;
        public HomeController(ItemService service) => _service = service;

        public IActionResult Index()
        {
            var items = _service.GetAll();
            ViewBag.TotalJuegos = items.Count;
            ViewBag.TotalGeneros = items.Select(i => i.Genero).Distinct().Count();
            ViewBag.UltimosJuegos = items.TakeLast(3).Reverse().ToList();
            return View();
        }

        public IActionResult Privacy() => View();
    }
}