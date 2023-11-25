using System;

namespace Product.Inventory.Service.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
