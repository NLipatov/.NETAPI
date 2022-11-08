using NETAPI.Entities;
using System;
using System.Collections.Generic;

namespace NETAPI.Repository
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid guid);
    }
}