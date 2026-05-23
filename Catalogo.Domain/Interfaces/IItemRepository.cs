using CatalogoApp.Domain.Models;

namespace CatalogoApp.Domain.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item? GetById(int id);
        void Add(Item item);
        void Update(Item item);
        void Delete(int id);
    }
}