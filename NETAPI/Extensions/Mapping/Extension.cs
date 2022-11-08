using NETAPI.DTOs;
using NETAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI
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
