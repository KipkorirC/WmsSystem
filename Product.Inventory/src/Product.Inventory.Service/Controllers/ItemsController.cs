using Microsoft.AspNetCore.Mvc;
using Product.Inventory.Service.Entities;
using Product.Inventory.Service.Repositories;
using Product.Inventory.Service.Dtos;
using System.Threading.Tasks;
using System.Collections;
using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;
using System.Collections.Generic;
using Product.Inventory.Service.Clients;

namespace Product.Inventory.Service.Controllers
{
       
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<InventoryItem> itemsRepository;

        private readonly CatalogClient catalogClient;

        public ItemsController(IRepository<InventoryItem> itemsRepository,CatalogClient catalogClient)
        {

           this.itemsRepository = itemsRepository;
           this.catalogClient = catalogClient;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return BadRequest();
            }

            var catalogItems = await catalogClient.GetCatalogItemsAsync();
            var inventoryItemEntities = await itemsRepository.GetAllAsync(item => item.UserId == userId);

            var inventoryItemDtos = inventoryItemEntities.Select(inventoryItem =>
            {
                var catalogItem = catalogItems.Single(catalogItem => catalogItem.Id == inventoryItem.CatalogItemId);
                return inventoryItem.AsDto(catalogItem.Name, catalogItem.Description);
            });
            

            
            return Ok(inventoryItemDtos);

        }
        [HttpPost]

        public async Task<ActionResult> PostAsync(GrantItemsDto grantItemsDto)
        {
            var InventoryItem = await itemsRepository.GetAsync(
                item => item.UserId == grantItemsDto.UserId && item.CatalogItemId == grantItemsDto.CatalogItemId);

            if (InventoryItem == null)
            {
                InventoryItem = new InventoryItem
                {
                    CatalogItemId = grantItemsDto.CatalogItemId,
                    UserId = grantItemsDto.UserId,
                    Quantity = grantItemsDto.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow

                };

                await itemsRepository.CreateAsync(InventoryItem);

            }
            else{
                InventoryItem.Quantity += grantItemsDto.Quantity;
                await itemsRepository.UpdateAsync(InventoryItem);

            }

            return Ok();
        }
    }
        
}