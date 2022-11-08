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

        // POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            Item item = new()
            {
                id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.id}, item.AsDto());
        }

        // PUT /items/{id}
        [HttpPut]
        [Route("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem == null)
            {
                return NotFound();
            }

            Item UpdatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(UpdatedItem);
            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            repository.DeleteItem(id);
            return NoContent();
        }
    }
}
