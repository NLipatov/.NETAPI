using Microsoft.AspNetCore.Mvc;
using SampleAPINet5.DTOs;
using SampleAPINet5.Entities;
using SampleAPINet5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPINet5.Controllers
{

    // GET /items
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }


        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(x => x.AsDto());
            return items;
        }


        // GET /items/{id}
        [HttpGet]
        [Route("items/{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id).AsDto();

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
