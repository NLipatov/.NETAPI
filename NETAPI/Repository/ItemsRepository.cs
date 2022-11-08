using NETAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly List<Item> Items = new()
        {
            new Item { id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return Items;
        }

        public Item GetItem(Guid id)
        {
            return Items.Where(x => x.id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            Items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            int Index = Items.FindIndex(x=>x.id == item.id);
            Items[Index] = item;
        }

        public void DeleteItem(Guid guid)
        {
            int Index = Items.FindIndex(x => x.id == guid);
            Items.RemoveAt(Index);
        }
    }
}
