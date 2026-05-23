using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _repo;
        public ItemService(IItemRepository repo) => _repo = repo;

        public List<Item> GetAll() => _repo.GetAll();

        public List<Item> GetByGenero(string genero) =>
            _repo.GetAll().Where(i =>
                i.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase)).ToList();

        public Item? GetById(int id) => _repo.GetById(id);

        public void Add(Item item) => _repo.Add(item);

        public void Delete(int id) => _repo.Delete(id);

        public void AgregarResena(int id, Resena resena)
        {
            var item = _repo.GetById(id);
            if (item == null) return;
            resena.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            item.Resenas.Add(resena);
            _repo.Update(item);
        }

        public List<string> GetGeneros() =>
            _repo.GetAll().Select(i => i.Genero)
                 .Distinct(StringComparer.OrdinalIgnoreCase)
                 .OrderBy(g => g).ToList();
    }
}