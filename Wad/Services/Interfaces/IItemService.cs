using Wad.Models;

namespace Wad.Services.Interfaces
{
    public interface IItemService
    {
        void CreateItem(Item item);
        void UpdateItem(Item item);

        void DeleteItem(Item item);

        List<Item> GetItems();

        Item GetItemById(int id);
    }
}
