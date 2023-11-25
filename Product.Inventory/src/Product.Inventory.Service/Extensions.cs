using Product.Inventory.Service.Dtos;
using Product.Inventory.Service.Entities;

namespace Product.Inventory.Service
{
    public static class Extensions
    {
        public static InventoryItemDto AsDto(this InventoryItem item,string name, string description)
        {
            return new InventoryItemDto(item.CatalogItemId,name,description, item.Quantity, item.AcquiredDate);
        }
    }
}