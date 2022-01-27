using SampleAPINet5.Entities;
using System;
using System.Collections.Generic;

namespace SampleAPINet5.Repository
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}