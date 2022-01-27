using SampleAPINet5.DTOs;
using SampleAPINet5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPINet5
{
    public static class Extension
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto 
            {
                id = item.id, 
                Name = item.Name, 
                CreatedDate = item.CreatedDate, 
                Price = item.Price
            };
        }
    }
}
