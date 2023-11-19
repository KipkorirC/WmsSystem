using Amazon.Util;
using Microsoft.AspNetCore.Mvc;
using Product.Catalog.Service.DTO;
using Product.Catalog.Service.Entities;
using Product.Catalog.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository itemsRepository;

        public ItemsController(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        // GET: items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            // Retrieve all items from the repository and convert them to DTOs
            var Items = (await itemsRepository.GetAllAsync()).Select(item => item.AsDto());
            return Items;
        }

        // GET: items/{id}
        [HttpGet("{Name}")]
        public async Task<ActionResult<ItemDto>> GetByNameAsync(string Name)
        {
            // Retrieve a specific item by its ID from the repository
            var item = await itemsRepository.GetAsync(Name);

            if (item == null)
            {
                return NotFound("Item not found");
            }

            return item.AsDto(); // Return the item as a DTO
        }

        // POST: items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {
            // Create a new item using the received data
            var item = new Item
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await itemsRepository.CreateAsync(item); // Add the new item to the repository

            // Return the created item's ID and the location to retrieve it
            return CreatedAtAction(nameof(GetByNameAsync), new { Name = item.Name }, item);
        }

        // PUT: items/{id}
        [HttpPut("{Name}")]
        public async Task<IActionResult> PutAsync(string Name, UpdateItemDto updateItemDto)
        {
            // Retrieve the existing item from the repository based on the ID
            var existingItem = await itemsRepository.GetAsync(Name);

            if (existingItem == null)
            {
                return NotFound(); // If the item doesn't exist, return Not Found status
            }

            // Update the existing item's properties with the new data
            existingItem.Name = updateItemDto.Name;
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;

            await itemsRepository.UpdateAsync(existingItem); // Update the item in the repository

            return NoContent(); // Return success status
        }

        // DELETE: items/{id}
        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteAsync(string Name)
        {
            // Retrieve the item from the repository based on the ID
            var Item = await itemsRepository.GetAsync(Name);

            if (Item == null)
            {
                return NotFound(); // If the item doesn't exist, return Not Found status
            }

            await itemsRepository.RemoveAsync(Item.Id); // Remove the item from the repository

            return NoContent(); // Return success status
        }
    }
}
