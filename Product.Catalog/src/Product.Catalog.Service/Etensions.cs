using MongoDB.Driver;
using Product.Catalog.Service.DTO;
using Product.Catalog.Service.Entities;

namespace Product.Catalog.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {


            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}