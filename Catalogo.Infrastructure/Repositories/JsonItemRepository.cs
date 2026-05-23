using System.Text.Json;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Infrastructure.Repositories
{
    public class JsonItemRepository : IItemRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _opts = new() { WriteIndented = true };

        public JsonItemRepository(string path) => _path = path;

        public List<Item> GetAll()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Item>>(json, _opts) ?? new();
        }

        public Item? GetById(int id) =>
            GetAll().FirstOrDefault(i => i.Id == id);

        public void Add(Item item)
        {
            var items = GetAll();
            item.Id = items.Count > 0 ? items.Max(i => i.Id) + 1 : 1;
            items.Add(item);
            Save(items);
        }

        public void Update(Item item)
        {
            var items = GetAll();
            var idx = items.FindIndex(i => i.Id == item.Id);
            if (idx >= 0) { items[idx] = item; Save(items); }
        }

        public void Delete(int id)
        {
            var items = GetAll();
            items.RemoveAll(i => i.Id == id);
            Save(items);
        }

        private void Save(List<Item> items) =>
            File.WriteAllText(_path, JsonSerializer.Serialize(items, _opts));
    }
}