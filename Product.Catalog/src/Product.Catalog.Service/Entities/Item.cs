using System;

namespace Product.Catalog.Service.Entities
{
    public class Item
    {
        internal int Quantity;

        // Properties of the Item entity
        public Guid Id { get; set; }            // Unique identifier for the item
        public string Name { get; set; }        // Name of the item
        public string Description { get; set; } // Description of the item
        public decimal Price { get; set; }      // Price of the item
        public DateTimeOffset CreatedDate { get; set; }  // Date and time when the item was created
    }
}
